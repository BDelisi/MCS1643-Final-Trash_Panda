using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 10;

    // Update is called once per frame
    void Update()
    {
        
    }

    // Method to be called by projectile that makes the player take damage according to the spell
    public void loseHealth(int projDamage)
    {
        health -= projDamage;
    }

}
