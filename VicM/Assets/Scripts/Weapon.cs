using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamage = 25;   // default to 25
    public int attackDuration = 1;
    private Collider2D weaponCollider;

    void Start()
    {
        weaponCollider = GetComponent<Collider2D>();
        weaponCollider.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine("HideCollider");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if weapon is hitting enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // deal damage to enemy
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(weaponDamage);

            // animate it
            enemy.animator.SetTrigger("attacked");
            StartCoroutine(enemy.ChangeSpeedTemporarily());
        }
    }

    private IEnumerator HideCollider()
    {
        weaponCollider.enabled = true;

        yield return new WaitForSeconds(attackDuration);

        weaponCollider.enabled = false;
    }
}
