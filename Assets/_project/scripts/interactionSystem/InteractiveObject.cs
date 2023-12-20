using UnityEngine;
using UnityEngine.Events;

public class InteractiveObject : KDTimer
{
    [SerializeField] private bool _isDisposable;

    [SerializeField] private GameObject _interactiveText;
    [SerializeField] private bool _isLookAtCam = true;

    [SerializeField] private UnityEvent _interactiveEvent;
    [SerializeField] private UnityEvent _enterEvent;
    [SerializeField] private UnityEvent _exitEvent;

    private void Update()
    {
        if (_isLookAtCam)
            _interactiveText.transform.LookAt(Camera.main.transform.position);
    }
    private void OnTriggerEnter(Collider _)
    {
        _interactiveText.SetActive(true);
        _enterEvent.Invoke();
    }

    private void OnTriggerExit(Collider _)
    {
        _interactiveText.SetActive(false);
        _exitEvent.Invoke();
    }

    private void OnTriggerStay(Collider _)
    {
        if (_isReady && Input.GetAxis(InputStrings.InteractionAxis) == 1)
        {
            _interactiveEvent.Invoke();
            if (_isDisposable)
            {
                gameObject.SetActive(false);
                return;
            }
            StartCoroutine(CheckKD());
        }
    }


}
