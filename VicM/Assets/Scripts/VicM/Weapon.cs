using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject weapon;
    private Animator weaponAnimator;
    private Animator vicAnimator;
    // Start is called before the first frame update
    void Start()
    {
        // get weaponAnimator
        weaponAnimator = weapon.GetComponent<Animator>();

        // get vicAnimator
        vicAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vicAnimator.SetTrigger("attack");
            weaponAnimator.SetTrigger("attack");
        }
    }
}
