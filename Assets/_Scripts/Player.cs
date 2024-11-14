using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health = 10;



    public KeyCode shoot;
    public GameObject projectile;
    private float cooldown;
    // Update is called once per frame
    void Update()
    {
        //Reduces cooldown and then allows the player to shoot if the cooldown is at or below zero
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            if (cooldown < 0)
            {
                cooldown = 0;
            }
        }
        else
        {
            if (Input.GetKey(shoot))
            {
                cooldown = 1;
                Instantiate(projectile, transform.position + transform.rotation * new Vector3(0, .65f, 1f), Quaternion.identity);
                
            }
        }
    }

    // Method to be called by projectile that makes the player take damage according to the spell
    public void loseHealth(int projDamage)
    {
        health -= projDamage;
    }

}
