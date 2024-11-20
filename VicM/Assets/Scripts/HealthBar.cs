using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // components
    public Slider slider;

    // set max possible health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // set current health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
