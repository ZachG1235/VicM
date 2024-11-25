using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormFry : Enemy
{
    // set damage that worm fry will do here
    public int wormFryDamage = 20;

    // overrides Enemy class function
    protected override void Start()
    {
        // call base start (from Enemy class script)
        base.Start();

        // set worm fry damage
        SetDamage(wormFryDamage);
    }
}
