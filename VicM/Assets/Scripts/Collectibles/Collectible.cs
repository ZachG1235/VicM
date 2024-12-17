using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            // dp pick up actions
            PickUp();
            Destroy(gameObject); // Destroy this GameObject (FullHeartPrefab)
        }
    }

    // default pick up action is increases vicm health by 10 for fullheart collectible
    public virtual void PickUp()
    {
        Debug.Log("You have been healed!");
        VicMStats.curSettings.maxHealth += 10;
        GameManager.SGameManager.VicM.GetComponent<Health>().MaximizeHealth();
    }
}
