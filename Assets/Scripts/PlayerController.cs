using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D rb2d;

    Animator animator;

    [SerializeField] float walkSpeed = 10f;
    [SerializeField] float jumpForce = 5f;

    private bool isGrounded;
    private int jumpCount;

    int maxJumps = 2;

    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        jumpCount = 0;
    }

    void Update()
    {
        Walk();
        FlipSprite();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }
        if (Input.GetKey(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            jumpCount++;
        }
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x*walkSpeed,rb2d.velocity.y);
        rb2d.velocity = playerVelocity;
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x)>Mathf.Epsilon;

        animator.SetBool("isWalking",playerHasHorizontalSpeed);

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector3(Mathf.Sign(rb2d.velocity.x)
                * Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb2d.velocity += new Vector2(0f, jumpForce);
        }
    }

}
