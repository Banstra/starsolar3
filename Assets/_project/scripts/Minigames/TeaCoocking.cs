using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.Events;

public class TeaCoocking : KDTimer
{
    [SerializeField] UnityEvent _endEvent;

    [SerializeField] GameObject _succsessImage;
    [SerializeField] GameObject _unsuccsessImage;
    [SerializeField] GameObject _UI;

    [SerializeField] Transform _arrow;
    [SerializeField] float _speed;
    [SerializeField] float _minX;
    [SerializeField] float _maxX;
    private float _startX;
    private bool _isCooking;
    private bool _isUsing;

    private void Start() =>
        _startX = _arrow.position.x;

    private void Update()
    {
        _isUsing = _UI.activeSelf;
        if (_isUsing == false) return;
        if (_isCooking)
            _arrow.position += transform.right * _speed * Time.deltaTime;
        if (Input.GetAxis(InputStrings.InteractionAxis) != 1) return;

        if (!_isCooking)
        {
            _isCooking = true;
            StartCoroutine(CheckKD());
        }
        else if(_isReady)
        {
            if(_arrow.localPosition.x > _minX && _arrow.localPosition.x < _maxX)
            {
                _succsessImage.SetActive(true);
                StartCoroutine(CloseUI(2));
            }
            else
            {
                _unsuccsessImage.SetActive(true);
                _arrow.position = new Vector3(_startX, _arrow.position.y);
            }
        }
    }

    public void ShowUI() =>
        _UI.SetActive(true);
    private IEnumerator CloseUI(float time)
    {
        _isCooking = false;
        enabled = false;
        yield return new WaitForSeconds(time);
        _endEvent.Invoke();
        gameObject.SetActive(false);
    }
}
