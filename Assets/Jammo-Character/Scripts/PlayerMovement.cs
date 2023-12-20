using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _JumpKd;
    private bool _isReadyToJump;
    [Space]

    [SerializeField] private bool _blockRotationPlayer;
    [SerializeField] private float _desiredRotationSpeed = 0.1f;
    [SerializeField] private float _allowPlayerRotation = 0.1f;
    [SerializeField] private Transform _camera;
    private Rigidbody _body;
    private Animator _anim;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    [SerializeField] private float StopAnimTime = 0.15f;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _body = GetComponent<Rigidbody>();
        _isReadyToJump = true;
    }

    private void FixedUpdate() =>
        InputMagnitude();

    private void InputMagnitude()
    {
        var inputX = Input.GetAxis(InputStrings.HorizontalAxis);
        var inputZ = Input.GetAxis(InputStrings.VerticalAxis);

        var direction = new Vector2(inputX, inputZ).sqrMagnitude;

        _anim.SetFloat("Blend", direction, StopAnimTime, Time.deltaTime);

        PlayerMoveAndRotation();
    }

    private void PlayerMoveAndRotation()
    {
        var inputX = Input.GetAxis(InputStrings.HorizontalAxis);
        var inputZ = Input.GetAxis(InputStrings.VerticalAxis);
        var inputJump = Input.GetAxis(InputStrings.JumpAxis);
        var inputRun = Input.GetAxis(InputStrings.RunAxis);

        var forward = _camera.transform.forward;
        var right = _camera.transform.right;

        var desiredMoveDirection = (forward * inputZ) + (right * inputX);

        var velocity = desiredMoveDirection * (inputRun == 1 ? _runSpeed : _speed);
        _body.velocity = new Vector3(velocity.x, _body.velocity.y, velocity.z);
        if (inputJump == 1 && _isReadyToJump)
            StartCoroutine(Jump());
    }

    private IEnumerator Jump()
    {
        _body.AddForce(new Vector3(0, _jumpForce));
        _isReadyToJump = false;
        yield return new WaitForSeconds(_JumpKd);
        _isReadyToJump = true;
    }
}
