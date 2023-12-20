using System.Collections;
using UnityEngine;

public class KDTimer : MonoBehaviour
{
    [SerializeField] protected float _timeKD = 1;
    protected bool _isReady = true;
    protected IEnumerator CheckKD()
    {
        _isReady = false;
        yield return new WaitForSeconds(_timeKD);
        _isReady = true;
    }
}
