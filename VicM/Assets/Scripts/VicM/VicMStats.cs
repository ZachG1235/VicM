using System.Collections;
using System.Collections.Generic;
using Unity.Loading;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class VicMStats : MonoBehaviour
{
    
    public struct VICMSETTINGS
    {   
        // implemented
        public int damage;

        // implemented
        public int critConstant;

        // implemented
        public float movementSpeed;

        // implemented
        public int maxHealth;

        // implemented
        public int defense;
    }

    static public VICMSETTINGS curSettings;

    private void Awake()
    {
        curSettings.damage = 5;
        curSettings.critConstant = 10;
        curSettings.movementSpeed = 6;
        curSettings.maxHealth = 100;
        curSettings.defense = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    static public int GetDamageWithDefense(int damage)
    {
        int tempVal = damage - curSettings.defense;
        if (tempVal < 2)
        {
            return 1;
        }
        return tempVal;
    }
    
    // function uses the crit constant and returns the damage,
    // if crit, damage is doubled
    static public int GetDamageWithCritChance()
    {
        int tempVal = Random.Range(0, curSettings.critConstant);
        if ( tempVal == curSettings.critConstant - 1 )
        {
            Debug.Log("you crit the bunny");
            return 2 * curSettings.damage;
        }
        return curSettings.damage;
    }
}
