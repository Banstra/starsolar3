using UnityEngine;

public class NeedPoseObject : MonoBehaviour
{
    [SerializeField] private Transform _needObject;

    [SerializeField] private Vector3 _needPosition;
    [SerializeField] private Vector3 _needRotation;

    public void PosedObject()
    {
        _needObject.localPosition = _needPosition;
        _needObject.rotation = Quaternion.Euler(_needRotation);
    }
}
