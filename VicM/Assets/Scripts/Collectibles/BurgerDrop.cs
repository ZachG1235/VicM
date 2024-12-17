using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerDrop : Collectible
{
    public GameObject entrancePrefab;
    private Vector3 spawnPoint = new Vector3 (0.4f, 9, 0);

    public override void PickUp()
    {
        // coin drops when burger is defeated

        // spawn exit door (so you can't just run past burgerboss without defeating it)
        GameObject newDoor = Instantiate<GameObject>(entrancePrefab);
        newDoor.transform.position = spawnPoint;

        Entrance entrance = newDoor.GetComponent<Entrance>();
        entrance.nextRoomNumber = 18;   // hub scene number # update if build scenes change

        // set vic m position in new scene
        entrance.vicsNextPos = Vector3.zero;

        // decide what to do here (stat increase, new weapon, whatever)
    }
}
