using System.Collections.Generic;
using UnityEngine;

public class EyesController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _normal;
    [SerializeField] private List<GameObject> _shocked;
    [SerializeField] private List<GameObject> _closed;

    private List<GameObject> _currentEmotion;

    [SerializeField] private float _changeKD;
    private readonly bool _isReady = true;

    private void Update()
    {
        if (!_isReady) return;

        if (Input.GetAxis(InputStrings.Emotion1Axis) == 1)
            ChangeEmotion(_normal);
        else if (Input.GetAxis(InputStrings.Emotion2Axis) == 1)
            ChangeEmotion(_shocked);
        else if (Input.GetAxis(InputStrings.Emotion3Axis) == 1)
            ChangeEmotion(_closed);
        else if (Input.GetAxis(InputStrings.RandomEmotionAxis) == 1)
            ChangeEmotion();
    }

    private void ChangeEmotion(List<GameObject> emotion)
    {
        if (_currentEmotion == emotion) return;

        if (_currentEmotion != null)
            foreach (var component in _currentEmotion)
                component.SetActive(false);

        foreach (var component in emotion)
            component.SetActive(true);

        _currentEmotion = emotion;
    }

    private void ChangeEmotion()
    {
        var emotions = new List<List<GameObject>> { _normal, _shocked, _closed };
        var index = Random.Range(0, emotions.Count);
        ChangeEmotion(emotions[index]);
    }
}
