using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/*
This script is for logging keys and cheat codes

it is currently attached to the EventSystem object
Thomas Rotchford 11/15/24
*/
public class Konami : MonoBehaviour
{
    private List<string> _keyStrokeHistory;

    void Awake()
    {
        _keyStrokeHistory = new List<string>();
    }
    void Update()
    {
        KeyCode keyPressed = DetectKeyPressed();
        AddKeyStrokeToHistory(keyPressed.ToString());
        if(GetKeyStrokeHistory().Equals("UpArrow,UpArrow,DownArrow,DownArrow,LeftArrow,RightArrow,LeftArrow,RightArrow,B,A"))
        {
            //functionality here
            VicMStats.curSettings.maxHealth = 10000;
            VicMStats.curSettings.critConstant = 1;
            VicMStats.curSettings.movementSpeed= 15;
            VicMStats.curSettings.defense = 25;
            VicMStats.curSettings.damage = 100;

            ClearKeyStrokeHistory();
        }
    }

    private KeyCode DetectKeyPressed()
    {
        foreach(KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(key))
            {
                return key;
            }
        }
        return KeyCode.None;
    }

    private void AddKeyStrokeToHistory(string keyStroke)
    {
        if(!keyStroke.Equals("None")) 
        {
            _keyStrokeHistory.Add(keyStroke);
            if(_keyStrokeHistory.Count>10)
            {
                _keyStrokeHistory.RemoveAt(0);
            }
        }
    }

    private string GetKeyStrokeHistory()
    {
        return String.Join(",", _keyStrokeHistory.ToArray());
    }
    
    private void ClearKeyStrokeHistory() {
        _keyStrokeHistory.Clear();
    }
}
