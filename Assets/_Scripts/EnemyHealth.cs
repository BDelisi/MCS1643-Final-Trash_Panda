using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Public vars
    public int health = 3;

    //Vars for hit flashes
    public float flashTime = .25f;
    public AudioSource takeDamage;
    public AudioSource die;
    SpriteRenderer spriteRenderer;
    Color origColor;

    // DOES NOT WORK ON 3D Objects
    //define the starting meshrenderer color and store it for later
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        origColor = spriteRenderer.material.color;
    }

    //Two methods to start and stop the hit flash
    public void FlashStart()
    {
        spriteRenderer.material.color = Color.red;
        Invoke("FlashStop", flashTime);
    }

    public void FlashStop()
    {
        spriteRenderer.material.color = origColor;
    }


    // Method to be called by projectile that makes the enemy take damage according to the spell
    public void enemyHit(int projDamage)
    {
        FlashStart();
        health -= projDamage;
        if (health <= 0)
        {
            die.Play();
            spriteRenderer.enabled = false;
            Destroy(gameObject, .25f);
            FindObjectOfType<Attacking>().RemoveEnemy(gameObject);
        } else
        {
            takeDamage.Play();
        }
    }


}
