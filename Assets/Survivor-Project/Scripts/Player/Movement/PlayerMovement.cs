using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private readonly int RunningHash = Animator.StringToHash("isRunning");

    [SerializeField] private DynamicJoystick joystick;
    [SerializeField] private PlayerSO playerSO;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Animator animator;

    private float horizontalMove;
    private float verticalMove;
    private Vector3 moveDirection;
    
    private void Update()
    {
        horizontalMove = joystick.Horizontal;
        verticalMove = joystick.Vertical;
        moveDirection = new Vector3(horizontalMove, 0, verticalMove).normalized;

        if (moveDirection != Vector3.zero)
        {
            animator.SetBool(RunningHash, true);
            rb.MovePosition(rb.position + moveDirection * playerSO.moveSpeed * Time.deltaTime);
        }                
        else
        {
            animator.SetBool(RunningHash, false);
        }
    }
}
