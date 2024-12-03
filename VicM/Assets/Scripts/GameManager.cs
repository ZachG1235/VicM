using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // game manager is singleton
    public static GameManager SGameManager;
    public GameObject VicMPrefab;
    public GameObject VicM;

    // depending on index, tell what rooms it will go to next
    private int[,] dungeon1Rooms = new int[17,4]
    {
        {3,0,0,0},   // room 1, so top door goes to room 3
        {6,3,0,0},   // room 2
        {7,4,1,2},   // room 3
        {8,0,0,3},   // room 4
        {9,0,0,0},   // room 5
        {10,0,2,0},  // room 6
        {11,8,3,0},  // room 7
        {0,9,4,7},   // room 8
        {13,0,5,8},  // room 9
        {14,11,6,0}, // room 10, top door goes to room 14, right door goes to 11, bottom 6, no left door
        {0,12,7,10}, // room 11
        {16,0,0,11}, // room 12
        {17,0,9,0},  // room 13
        {0,15,10,0}, // room 14
        {0,16,0,14}, // room 15
        {0,0,12,15}, // room 16
        {0,0,13,0},  // room 17
    };

    private Vector3[] dungeon1DoorPositions = new Vector3[4]
    {
        new Vector3 (0.4f, 9, 0),
        new Vector3 (13f, 2, 0),
        new Vector3 (0.4f, -7, 0),
        new Vector3 (-12f, 2, 0),
    };

    private int currentRoom;
    public GameObject entrancePrefab;
    public Animator transitioner;

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

            // check if vicM exists
            if (VicM == null)
            {
                // create vicM if not
                VicM = Instantiate<GameObject>(VicMPrefab);
            }
            DontDestroyOnLoad(gameObject);

            // set roomNumber
            currentRoom = 0;
        }
    }

    public void ChangeRoom(int roomNumber, Vector3 newPos)
    {
        // set roomNumber
        currentRoom = roomNumber;

        // load into new room
        transitioner.SetTrigger("end");
        SceneManager.LoadScene(currentRoom);
        transitioner.SetTrigger("start");

        // check if loading into dungeon room
        if (currentRoom > 0)
        {
            StartCoroutine(GenerateDoors());
        }

        VicM.transform.position = newPos;
    }

    public IEnumerator GenerateDoors()
    {
        yield return new WaitForSeconds(2);

        Debug.Log("GENERATING DOORS!");
        // loop through doors array for current dungeon room
        for (int door = 0; door < 4; door++)
        {
            // check if there is a door
            if (dungeon1Rooms[currentRoom - 1,door] > 0)
            {
                // create new door at correct place
                GameObject newDoor = Instantiate<GameObject>(entrancePrefab);
                newDoor.transform.position = dungeon1DoorPositions[door];

                Entrance entrance = newDoor.GetComponent<Entrance>();
                entrance.nextRoomNumber = dungeon1Rooms[currentRoom - 1,door];

                int nextPos;
                if (door == 0) nextPos = 2;
                else if (door == 1) nextPos = 3;
                else if (door == 2) nextPos = 0;
                else nextPos = 1;

                // set vic m position in new scene
                entrance.vicsNextPos = dungeon1DoorPositions[nextPos];
            }
        }
    }
}
