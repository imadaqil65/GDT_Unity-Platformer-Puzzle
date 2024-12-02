using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderClimbing : MonoBehaviour
{
    private bool isNearLadder = false;
    private bool isClimbing = false;
    private Rigidbody2D rb;

    [SerializeField] private float climbSpeed = 5f;  // Adjust this value to control climb speed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        if (isNearLadder && Mathf.Abs(verticalInput) > 0.1f)
        {
            StartClimbing(verticalInput);
        }
        else if (isClimbing && Mathf.Abs(verticalInput) <= 0.1f)
        {
            StopClimbing();
        }
    }

    private void StartClimbing(float verticalInput)
    {
        isClimbing = true;
        rb.gravityScale = 0;  // Disable gravity while climbing
        rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbSpeed);  // Move player up or down based on input
    }

    private void StopClimbing()
    {
        isClimbing = false;
        rb.gravityScale = 9;  // Reset gravity scale (adjust to match your player’s normal gravity)
        rb.velocity = new Vector2(rb.velocity.x, 0);  // Stop vertical movement
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isNearLadder = true;
            Debug.Log("Entered ladder area");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isNearLadder = false;
            StopClimbing();
            Debug.Log("Exited ladder area");
        }
    }
}
