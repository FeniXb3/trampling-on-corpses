using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    [SerializeField] private IUnityService unityService;

    private Rigidbody2D rb;
    private Movement movement;
    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        movement = new Movement(speed);


        if (unityService == null)
        {
            unityService = new UnityService();
        }
    }

    private void FixedUpdate()
    {
        var horizontalSpeed = movement.GetHorizontalSpeed();

        if (horizontalSpeed > 0) // maybe more optimised than adding Vector3(0,0,0) to position even when standing still
        {
            MoveHorizontally();
        }

        if (unityService.GetButton("Jump") && !isJumping)
        {
            Jump();
        }
    }

    private void MoveHorizontally()
    {
        transform.position += movement.CalculateHorizontal(
            unityService.GetAxisRaw("Horizontal"),
            unityService.GetDeltaTime());
    }

    private void Jump()
    {
        isJumping = true;
        rb.AddForce(movement.CalculateJump(jumpForce), ForceMode2D.Impulse);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

}