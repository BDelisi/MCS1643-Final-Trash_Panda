using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private int health;

    public void UpdateHealth(int newHealth)
    {
        health = newHealth;
        GetComponent<Slider>().value = health;
    }
}
