using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Player Movement
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        // Prevent faster diagonal
        moveInput.Normalize();

        if (animator != null)
        {
            bool isMoving = moveInput.sqrMagnitude > 0;
            animator.SetBool("isMoving", isMoving);
        }

        // Flip sprite
        if (spriteRenderer != null)
        {
            if (moveInput.x > 0)
                spriteRenderer.flipX = false;
            else if (moveInput.x < 0)
                spriteRenderer.flipX = true;
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * moveSpeed * Time.fixedDeltaTime);
    }
}