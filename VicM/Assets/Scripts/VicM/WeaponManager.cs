using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<GameObject> weapons;
    private GameObject currentWeapon;
    private Animator weaponAnimator;
    private Animator vicAnimator;
    public int weaponDamage = 25;
    //private int numOfWeapons = 1;

    // weapon prefabs
    public GameObject chopsticks;

    // Start is called before the first frame update
    void Start()
    {
        // get vicAnimator
        vicAnimator = GetComponent<Animator>();

        // initialize weapon list
        weapons = new List<GameObject>
        {
            // add chopsticks to list
            chopsticks
        };

        // set chopsticks as default
        // if we do saving, i think we'd just save the number/index of the weapon
        SetWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        // check for attack
        if (Input.GetMouseButtonDown(0))
        {
            // animate attack
            vicAnimator.SetTrigger("attack");
            weaponAnimator.SetTrigger("attack");
        }
    }

    public void SetWeapon(int weapon)
    {
        // check if currentweapon has already been instantiated
        if (currentWeapon != null)
        {
            Destroy(currentWeapon);
        }

        // spawn in new weapon
        currentWeapon = Instantiate<GameObject>(weapons[weapon]);

        // set current weapon as child to vicM
        currentWeapon.transform.SetParent(gameObject.transform);

        // i honestly have no idea how it ends up in the right spot
        //currentWeapon.transform.position = Vector3.zero;

        // get weaponAnimator
        weaponAnimator = currentWeapon.GetComponent<Animator>();
    }
}
