using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Public vars
    public int health = 3;

    // Method to be called by projectile that makes the enemy take damage according to the spell
    public void loseHealth(int projDamage)
    {
        health -= projDamage;
        if (health <= 0)
        {
            FindObjectOfType<Attacking>().RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
    }


}
