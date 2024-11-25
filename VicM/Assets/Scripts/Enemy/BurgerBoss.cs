using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BurgerBoss : Enemy
{
    // get "fry weapon" collider
    private Collider2D fryColl;

    // set damage that burger boss does here
    public int burgerDamage = 50;

    // override enemy start function
    protected override void Start()
    {
        // call base start (calls Enemy class start function)
        base.Start();

        // get fry weapon collider
        fryColl = GetComponents<Collider2D>()[0];

        // disable it until attack
        fryColl.enabled = false;

        // set damage amount (in Enemy class)
        SetDamage(burgerDamage);
    }

    // overrides Enemy class Attack function (burger has different attack)
    public override void Attack()
    {
        // enable fry collider
        fryColl.enabled = true;

        // call function from enemy
        base.Attack();

        // disable again
        fryColl.enabled = false;
    }
}
