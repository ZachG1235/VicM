using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VicMMovement : MonoBehaviour
{
    // get animator
    private Animator animator;

    // player speed
    public float moveSpeed;
    float speedX, speedY;

    // components
    Rigidbody2D rb;
    SpriteRenderer sr;

    void Start()
    {
        // get rigid body
        rb = GetComponent<Rigidbody2D>();

        // get sprite renderer
        sr = GetComponent<SpriteRenderer>();

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
        if (speedX == 0)
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
            if (speedX > 0)
            {
                sr.flipX = true;
            }
            if (speedX < 0)
            {
                sr.flipX = false;
            }
        }

        // set vicM movement
        rb.velocity = new Vector2(speedX, speedY);
    }
}
