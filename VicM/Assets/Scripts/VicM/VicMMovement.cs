using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VicMMovement : MonoBehaviour
{
    // player attributes
    public float moveSpeed;
    float speedX, speedY;
    private bool isFacingRight = false; // faces left by default

    // components
    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        // get rigid body
        rb = GetComponent<Rigidbody2D>();

        // get animator
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // move vicM based on inputs
        speedX = Input.GetAxisRaw("Horizontal") * moveSpeed;
        speedY = Input.GetAxisRaw("Vertical") * moveSpeed;

        // check for idle
        if (speedX == 0 && speedY == 0)
        {
            // set vicM isWalking to false
            animator.SetBool("isWalking", false);
        }
        // otherwise, assume player is moving
        else
        {
            // set vicM isWalking to true
            animator.SetBool("isWalking", true);

            // flip character if moving left or right
            if (speedX > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (speedX < 0 && isFacingRight)
            {
                Flip();
            }
        }

        // set vicM movement
        rb.velocity = new Vector2(speedX, speedY);

        // set enemy pos to vicM position
        Enemy.VICMPOS = transform.position;

    }

    private void Flip()
    {
        // Toggle the facing direction
        isFacingRight = !isFacingRight;

        // Flip the character by changing the scale
        Vector3 scale = transform.localScale;

        // Invert the x-axis scale to flip the character
        scale.x *= -1;

        // set local scale to sclae
        transform.localScale = scale;
    }


}
