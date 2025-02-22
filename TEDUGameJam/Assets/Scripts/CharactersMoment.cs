using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersMoment : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;

    private bool isGrounded;
    private int jumpCount;
    private int maxJumpCount = 2;
    

    private float horizontalInput;

    void Start()
    {
        jumpCount = maxJumpCount;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
      
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);
        if (horizontalInput == 0) {
            animator.SetBool("isRunning", false);
        }
        else {
            animator.SetBool("isRunning", true);
        }
        if (horizontalInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        if (horizontalInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
            jumpCount = 0;

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumpCount))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }
}
   