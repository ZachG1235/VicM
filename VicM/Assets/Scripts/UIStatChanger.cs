using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStatChanger : MonoBehaviour
{
    public Text _statMenu;
    public GameObject statObject;

    private float moveSpeedDisplay;
    private int damageDisplay;
    private string critDisplay;
    private int defenseDisplay;
    private int maxHealthDisplay;
    
    void Awake()
    {
        DontDestroyOnLoad(statObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        moveSpeedDisplay = VicMStats.curSettings.movementSpeed;
        damageDisplay = VicMStats.curSettings.damage;
        critDisplay = (1f / VicMStats.curSettings.critConstant * 100f).ToString("F2");
        defenseDisplay = VicMStats.curSettings.defense;
        maxHealthDisplay = VicMStats.curSettings.maxHealth;
        

        _statMenu.text = "Move Speed: "   + moveSpeedDisplay + "\n" +
                         "Damage: "      + damageDisplay + "\n" +
                         "Crit Chance: " + critDisplay + "%\n" + 
                         "Defense: "     + defenseDisplay + "\n" + 
                         "Max Health: "  + maxHealthDisplay;
    }

    // Update is called once per frame
    void Update()
    {
        moveSpeedDisplay = VicMStats.curSettings.movementSpeed;
        damageDisplay = VicMStats.curSettings.damage;
        critDisplay = (1f / VicMStats.curSettings.critConstant * 100f).ToString("F2");
        defenseDisplay = VicMStats.curSettings.defense;
        maxHealthDisplay = VicMStats.curSettings.maxHealth;


        _statMenu.text = "Move Speed: " + moveSpeedDisplay + "\n" +
                         "Damage: " + damageDisplay + "\n" +
                         "Crit Chance: " + critDisplay + "%\n" +
                         "Defense: " + defenseDisplay + "\n" +
                         "Max Health: " + maxHealthDisplay;
    }
}
