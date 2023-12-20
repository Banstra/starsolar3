using UnityEngine;

public class PinkstarClearCheck : MonoBehaviour
{
    [SerializeField] private float _propsCount;
    [SerializeField] private string _cutsceneName;

    private int _countUsedProps = 0;

    public void UseProp()
    {
        _countUsedProps++;
        if (_countUsedProps >= _propsCount)
            CutsceneStart.Start(_cutsceneName);

    }
}
