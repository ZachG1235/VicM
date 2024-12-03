using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorSceneChange : MonoBehaviour
{
    public string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object colliding is the player
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player collided with door. Scene Changed!");
            SceneManager.sceneLoaded += OnSceneLoaded; // Subscribe to sceneLoaded event
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the player in the new scene and set their position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = Vector3.zero; // Set to (0, 0, 0)
        }

        // Unsubscribe to avoid duplicate calls
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
