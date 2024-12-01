using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Get VICMPOS position
    static public Vector3 VICMPOS;
    public int MoveSpeed = -5;    // Speed at which the enemy moves
    public int MaxDist = 1;     // Max distance to the player to start an action
    public int MinDist = -10;      // Min distance from the player to stop or act
    private bool isFacingRight = true; // faces right by default
    private SpriteRenderer sr;
    public Animator animator;
    private Rigidbody2D rb;
    public HealthBar healthBar;
    public int maxHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        // get components
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        // set max health
        // should be able to edit this for buffs/stat increases or whatever 
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the direction to the VICMPOS (player position)
        Vector3 directionToTarget = VICMPOS - transform.position;
        float distanceToTarget = directionToTarget.magnitude;

        // Only move if the distance to the target is greater than MinDist
        if (distanceToTarget >= MinDist)
        {
            // Normalize direction so that movement speed is consistent
            directionToTarget.Normalize();

            // Move towards the VICMPOS
            transform.position += directionToTarget * MoveSpeed * Time.deltaTime;

            //BUG;
            //flipping the health bar is confusing only flip the character
            if (directionToTarget.x > 0 && !isFacingRight)
            {
                Flip();
            }
            else if (directionToTarget.x < 0 && isFacingRight)
            {
                Flip();
            }
            

            // Check if within MaxDist for triggering actions
            if (distanceToTarget <= MaxDist)
            {
                // Call any function you want when within MaxDist, like shooting
                Debug.Log("Enemy is within MaxDist, triggering action");
                animator.SetTrigger("attack");
                StartCoroutine("ChangeSpeedTemporarily");
            }
        }
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

    public void TakeDamage(int damage)
    {
        // remove from maxhealth
        maxHealth -= damage;

        // set new health
        healthBar.SetHealth(maxHealth);

        // check if no more health
        if (maxHealth <= 0)
        {
            // "enemy" dies
            // can make it drop something here if we want
            Destroy(gameObject);
        }
    }

    // this is used to make the enemy stop moving temporarily if it gets hit or attacks
    public IEnumerator ChangeSpeedTemporarily()
    {
        MoveSpeed = 0;

        yield return new WaitForSeconds(2);

        MoveSpeed = 1;
    }
}