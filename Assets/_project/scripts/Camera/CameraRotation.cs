using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private const float _threshold = 0.01f;

    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _verticalSpeed;

    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;

    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;

    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;

    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void LateUpdate() =>
        CameraRotate();

    private void CameraRotate()
    {
        var x = Input.GetAxis(InputStrings.MouseXAxis);
        var y = Input.GetAxis(InputStrings.MouseYAxis);

        var look = new Vector3(x, y);
        if (look.sqrMagnitude >= _threshold)
        {
            _cinemachineTargetYaw += look.x * Time.deltaTime * _horizontalSpeed;
            _cinemachineTargetPitch += look.y * Time.deltaTime * _verticalSpeed;
        }

        _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
        _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
            _cinemachineTargetYaw, 0.0f);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }
}
