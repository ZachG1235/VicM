using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // game manager is singleton
    public static GameManager SGameManager;
    public GameObject VicM;

    // depending on index, tell what rooms it will go to next
    private int[,] dungeon1Rooms = new int[17,4]
    {
        {3,0,0,0},  // this is room 1, so top door goes to room 3
        {6,3,0,0},
        {7,4,1,2},
        {8,0,0,3},
        {9,0,0,0},
        {10,0,2,0},
        {11,8,3,0},
        {0,9,4,7},
        {13,0,5,8},
        {14,11,6,0},
        {0,12,7,10},
        {16,0,0,11},
        {17,0,9,0},
        {0,15,10,0},
        {0,16,0,14},
        {0,0,12,15},
        {0,0,13,0},
    };

    private int currentRoom;

    void Awake()
    {
        // If there is already an instance, destroy this one
        if (SGameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            // Set this instance as the only one
            SGameManager = this;
            DontDestroyOnLoad(gameObject);

            // set roomNumber
            currentRoom = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeRoom(int roomNumber, Vector3 newPos)
    {
        // set roomNumber
        currentRoom = roomNumber;

        // load into new room
        SceneManager.LoadScene(currentRoom);

        VicM.transform.position = newPos;
    }
}
