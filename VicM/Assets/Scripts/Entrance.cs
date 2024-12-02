using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public int nextRoomNumber;
    public Vector3 vicsNextPos;

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            GameManager.SGameManager.ChangeRoom(nextRoomNumber, vicsNextPos);
        }
    }
}
