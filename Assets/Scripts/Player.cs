using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject body;

    private IInputService inputService;
    private ITimeService timeService;

    private Movement movement;
    private Animator animator;
    private SpriteRenderer bodySpriteRenderer;
    private Rigidbody2D rb;

    private bool isJumping;

    private void Start()
    {
        movement = new Movement(speed, jumpForce);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (inputService == null)
        {
            inputService = new UnityInputService();
        }

        if (timeService == null)
        {
            timeService = new UnityTimeService();
        }

        ObtainRandomColor();
    }

    private void FixedUpdate()
    {
        var horizontalSpeed = movement.GetHorizontalSpeed();

        animator.SetFloat("HorizontalSpeed", horizontalSpeed);

        if (ShouldMove()) // maybe more optimised than adding Vector3(0,0,0) to position even when standing still
        {
            MoveHorizontally();
        }

        if (ShouldJump())
        {
            Jump();
        }
    }

    private void ObtainRandomColor()
    {
        var randomColor = Random.ColorHSV(0, 1f, .25f, .25f, .75f, .75f);
        body.GetComponent<SpriteRenderer>().color = randomColor;
    }

    private void MoveHorizontally()
    {
        transform.position += movement.CalculateHorizontal(
            inputService.GetAxisRaw("Horizontal"),
            timeService.GetDeltaTime());
    }

    private void Jump()
    {
        isJumping = true;
        rb.AddForce(movement.CalculateJump(), ForceMode2D.Impulse);
        animator.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetTrigger("Land");
        }
    }

    private bool ShouldMove()
    {
        return movement.GetHorizontalSpeed() > 0;
    }

    private bool ShouldJump()
    {
        return inputService.GetButton("Jump") && !isJumping;
    }
}