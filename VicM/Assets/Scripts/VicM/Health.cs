using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 100;    // default to 100
    public GameObject fullHeartPrefab;
    public GameObject halfHeartPrefab;
    public Transform heartContainer;

    // Start is called before the first frame update
    void Start()
    {
        // create hearts
        CreateHearts();
    }

    private void CreateHearts()
    {
        // delete hearts if there are any
        foreach (Transform child in heartContainer)
        {
            Destroy(child.gameObject);
        }

        // Generate full hearts first
        int fullHeartsCount = health / 20;  // Calculate full hearts (each worth 20 health)
        int remainingHealth = health % 20;  // Calculate remaining health (less than 20)

        // Instantiate full hearts
        for (int i = 0; i < fullHeartsCount; i++)
        {
            GameObject newHeart = Instantiate(fullHeartPrefab, heartContainer);
            newHeart.transform.localPosition = new Vector3(80 * i, 0, 0);  // Position hearts
        }

        // If there's remaining health less than 20, create a half-heart
        if (remainingHealth > 0)
        {
            GameObject newHalfHeart = Instantiate(halfHeartPrefab, heartContainer);
            newHalfHeart.transform.localPosition = new Vector3(80 * fullHeartsCount, 0, 0);  // Position the half-heart
        }
    }

    public void TakeDamage(int damage)
    {
        //Debug.Log(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name);
        if (GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "VicM_Dodge") return;
        Debug.Log("We just lost " + damage + " health!");
        health -= damage;

        // display new health amount
        CreateHearts();

        if (health <= 0)
        {
            // END GAME HERE
            //SceneManager.LoadScene(0);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        // check if enemy was attacking player
        if (coll.gameObject.CompareTag("EnemyAttack"))
        {
            // take damage
            // damage depends on enemies individual damage value
            TakeDamage(coll.gameObject.GetComponent<Enemy>().damage);
        }
    }
}
