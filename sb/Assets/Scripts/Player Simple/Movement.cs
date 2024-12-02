using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float groundSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] Animator animator;
    [SerializeField] Rigidbody2D body;
    [SerializeField] float jumpTime;
    
    [Header("Ground Check")]
    [SerializeField] Vector2 boxSize;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float castDistance;

    [Header("Coyote Time Settings")]
    [SerializeField] float coyoteTime; // Adjust this value to control how long coyote time lasts
    private float coyoteTimeCounter;

    float jumpTimeCounter;
    bool isGrounded;
    bool isJumping;

    void Update()
    {
        // Check if grounded via BoxCast
        isGrounded = Physics2D.BoxCast(groundCheck.position, boxSize, 0, Vector2.down, castDistance, groundLayer);

        if (isGrounded)
        {
            // Reset coyote time counter when grounded
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            // Count down coyote time counter when not grounded
            coyoteTimeCounter -= Time.deltaTime;
        }

        float xInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(xInput * groundSpeed, body.velocity.y);

        // Flip character direction
        if (xInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (xInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }

        // Jump
        PlayerJump();

        // Set animation boolean
        animator.SetBool("Walk", xInput != 0);
        animator.SetBool("grounded", isGrounded);
    }

    void PlayerJump()
    {
        // Jump initiation
        if (Input.GetButtonDown("Jump") && (isGrounded || coyoteTimeCounter > 0f))
        {
            animator.SetTrigger("jump");
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
            isJumping = true;
            isGrounded = false;
            jumpTimeCounter = jumpTime;
        }

        // Jump hold mechanic (variable jump height)
        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                body.velocity = new Vector2(body.velocity.x, jumpSpeed);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    void OnDisable()
    {
        body.velocity = new Vector2(0,0);
        body.bodyType = RigidbodyType2D.Kinematic;
        animator.SetBool("Walk", false);
    }

    void OnEnable()
    {
        body.bodyType = RigidbodyType2D.Dynamic;
    }

    // Optional: Debugging tool to visualize the ground check ray
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position - transform.up * castDistance, boxSize);
    }
}
