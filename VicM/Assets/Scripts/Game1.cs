using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game1 : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with door. Scene Changed!");
            //GameManager.SGameManager.VicM.GetComponent<Health>().TakeDamage(99999999);
            SceneManager.LoadScene(sceneName);
        }
    }
}
