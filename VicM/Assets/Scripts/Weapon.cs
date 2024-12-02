using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int weaponDamage = 15;   // default to 25

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // check if weapon is hitting enemy
        if (collision.gameObject.CompareTag("Enemy")
            || collision.gameObject.CompareTag("EnemyAttack"))
        {
            // deal damage to enemy
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.TakeDamage(weaponDamage + VicMStats.GetDamageWithCritChance(), true);

            // animate it
            enemy.animator.SetTrigger("attacked");
            StartCoroutine(enemy.ChangeSpeedTemporarily());
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        // check if weapon is hitting enemy
        if (coll.CompareTag("Enemy")
            || coll.CompareTag("EnemyAttack"))
        {
            // deal damage to enemy
            Enemy enemy = coll.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(weaponDamage + VicMStats.GetDamageWithCritChance(), false);

                // animate it
                enemy.animator.SetTrigger("attacked");
                StartCoroutine(enemy.ChangeSpeedTemporarily());
            }
        }
    }
}
