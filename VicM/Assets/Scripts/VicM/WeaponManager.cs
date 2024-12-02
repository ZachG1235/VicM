using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private List<GameObject> weapons;
    private GameObject currentWeapon;
    private GameObject currentSpecial;
    private Animator weaponAnimator;
    private Animator specialAnimator;
    private Animator vicAnimator;
    public int weaponDamage = 25;
    //private int numOfWeapons = 1;

    private bool specialAttackActivated = false;
    // weapon prefabs
    public GameObject chopsticks;
    public GameObject soySauce;

    // Start is called before the first frame update
    void Start()
    {
        // get vicAnimator
        vicAnimator = GetComponent<Animator>();

        // initialize weapon list
        weapons = new List<GameObject>
        {
            // add default weapons to list
            chopsticks,
            soySauce
        };

        // set chopsticks as default
        // if we do saving, i think we'd just save the number/index of the weapon
        SetWeapon(0);
        SetSpecial(1);
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
        // check for special attack
        else if (Input.GetMouseButtonDown(1) && !specialAttackActivated)
        {
            StartCoroutine(SpecialAttack());
        }

        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            vicAnimator.SetBool("dodge", true);
        }
        else
        {
            vicAnimator.SetBool("dodge", false);
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

    public void SetSpecial(int special)
    {
        // check if currentweapon has already been instantiated
        if (currentSpecial != null)
        {
            Destroy(currentSpecial);
        }

        // spawn in new weapon
        currentSpecial = Instantiate<GameObject>(weapons[special]);

        // set current weapon as child to vicM
        currentSpecial.transform.SetParent(gameObject.transform);

        // i honestly have no idea how it ends up in the right spot
        //currentWeapon.transform.position = Vector3.zero;

        // get weaponAnimator
        specialAnimator = currentSpecial.GetComponent<Animator>();
    }

    public IEnumerator SpecialAttack()
    {
        specialAttackActivated = true;

        // disable currentWeapon
        currentWeapon.SetActive(false);

        // animate attack
        vicAnimator.SetTrigger("specialAttack");
        specialAnimator.SetTrigger("specialAttack");

        yield return new WaitForSeconds(7.16f);

        specialAttackActivated = false;

        // enable currentWeapon
        currentWeapon.SetActive(true);
    }
}
