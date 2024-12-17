using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoyBaby : Collectible
{
    public override void PickUp()
    {
        // here we can increase the number of soybabies collected or something?
        Debug.Log("soybaby collected!");
    }
}
