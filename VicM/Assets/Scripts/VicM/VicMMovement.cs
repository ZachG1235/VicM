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
    private Collider2D collisionThing;

    void Awake()
    {
        // so that VicM stays through scene loads
        DontDestroyOnLoad(gameObject);
        
    }
    void Start()
    {
        // get rigid body
        rb = GetComponent<Rigidbody2D>();

        // get animator
        animator = GetComponent<Animator>();

        // get collider
        collisionThing = GetComponent<Collider2D>();

        moveSpeed = VicMStats.curSettings.movementSpeed;
        Debug.Log(moveSpeed);
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

            // this code makes vic face direction moving
            // flip character if moving left or right
            if (speedX > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (speedX < 0 && isFacingRight)
            {
                Flip();
            }

            // this code makes vic face where mouse is facing
            // Get the mouse position in world space
            // Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // // Check if the mouse is to the left or right of the character
            // if (mouseWorldPosition.x > transform.position.x && !isFacingRight)
            // {
            //     Flip();
            // }
            // else if (mouseWorldPosition.x < transform.position.x && isFacingRight)
            // {
            //     Flip();
            // }
        }

        if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "VicM_Dodge")
        {
            collisionThing.enabled = false;
            
        }
        else
        {
            collisionThing.enabled = true;
        }

        // set vicM movement
        rb.velocity = new Vector2(speedX, speedY);

        // set enemy pos to vicM position
        Enemy.VICMPOS = transform.position;

        moveSpeed = VicMStats.curSettings.movementSpeed;
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
