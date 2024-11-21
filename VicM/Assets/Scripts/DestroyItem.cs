using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with FullHeartPrefab. Destroying it!");
            Destroy(gameObject); // Destroy this GameObject (FullHeartPrefab)
        }
    }
}
