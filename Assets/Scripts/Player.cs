using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundedLayerMask;

    private IInputService inputService;
    private ITimeService timeService;

    private Movement movement;
    private Animator animator;
    private Rigidbody2D rb;

    private bool isJumping;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        movement = new Movement(speed, jumpForce);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        LoadServices();
        SetSpawnPosition();
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

    private void LoadServices()
    {
        if (inputService == null)
        {
            inputService = new UnityInputService();
        }

        if (timeService == null)
        {
            timeService = new UnityTimeService();
        }
    }

    private void SetSpawnPosition()
    {
        var spawnPoint = GameObject.FindWithTag("SpawnPoint");
        if (spawnPoint != null)
        {
            transform.position = spawnPoint.transform.position;
        }
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

    private bool IsGrounded()
    {
        const float distance = 1.1f;

        var position = transform.position;
        var direction = Vector2.down;
        var hit = Physics2D.Raycast(position, direction, distance, groundedLayerMask);

        return hit.collider != null;
    }

    private bool ShouldMove()
    {
        return movement.GetHorizontalSpeed() > 0;
    }

    private bool ShouldJump()
    {
        return inputService.GetButton("Jump") && !isJumping && IsGrounded();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground") && IsGrounded())
        {
            isJumping = false;
            animator.SetTrigger("Land");
        }
    }
}