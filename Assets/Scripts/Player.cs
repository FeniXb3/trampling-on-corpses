using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundedLayerMask;
    [SerializeField] private GameObject spawnPointPrefab;

    private IInputService inputService;
    private ITimeService timeService;

    private Movement movement;
    private Animator animator;
    private Rigidbody2D rb;

    private bool isJumping;
    private bool jumpCooldown;
    private bool isGrounded;

    private readonly Vector2[] raycastOffsets = new Vector2[3] {new Vector2(-0.5f, 0f), new Vector2(0f, 0f), new Vector2(0.5f, 0f)}; 
    private readonly List<RaycastHit2D> contactPoints = new List<RaycastHit2D>();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SetSpawnPosition();
    }

    private void Start()
    {
        movement = new Movement(speed, jumpForce);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        LoadServices();
    }

    private void FixedUpdate()
    {
        isGrounded = CheckGround();

        animator.SetFloat("HorizontalSpeed", movement.GetHorizontalSpeed());

        if (ShouldMove()) // maybe more optimised than adding Vector3(0,0,0) to position even when standing still
        {
            MoveHorizontally();
        }

        if (ShouldJump())
        {
            Jump();
            StartCoroutine(JumpCooldown());
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

        if (spawnPoint == null)
        {
            spawnPoint = Instantiate(spawnPointPrefab, transform.position, transform.rotation);
        }

        transform.position = spawnPoint.transform.position;
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

    private bool CheckGround()
    {
        const float distance = 1.1f;
        var direction = Vector2.down;

        foreach (var offset in raycastOffsets)
        {
            var position = (Vector2) transform.position + offset;
            contactPoints.Add(Physics2D.Raycast(position, direction, distance, groundedLayerMask));
        }

        return contactPoints.Any(contactPoint => contactPoint.collider != null);
    }

    private bool ShouldMove()
    {
        return movement.GetHorizontalSpeed() > 0;
    }

    private bool ShouldJump()
    {
        return inputService.GetButton("Jump") && !isJumping && !jumpCooldown && isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            animator.SetTrigger("Land");
        }
    }

    IEnumerator JumpCooldown()
    {
        jumpCooldown = true;
        yield return new WaitForSeconds(0.5f);
        jumpCooldown = false;
    }
}