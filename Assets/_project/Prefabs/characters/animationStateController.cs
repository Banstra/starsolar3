using UnityEngine;

public class animationStateController : MonoBehaviour
{
    private Animator _animator;

    private void Start() =>
        _animator = GetComponent<Animator>();

    private void Update()
    {
        var h = Input.GetAxis(InputStrings.HorizontalAxis);
        var v = Input.GetAxis(InputStrings.VerticalAxis);

        bool isWalking = _animator.GetBool("isWalking") | _animator.GetBool("isWalkingBack");
        bool moving = h > 0 || v < 0;
        bool movingBack = h < 0 || v > 0;

        if (!isWalking && moving)
            _animator.SetBool("isWalking", true);

        if (isWalking && !moving)
            _animator.SetBool("isWalking", false);

        if (!isWalking && movingBack)
            _animator.SetBool("isWalkingBack", true);

        if (isWalking && !movingBack)
            _animator.SetBool("isWalkingBack", false);
    }
}
