using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public AudioSource[] footsteps;
    public int health = 8;
    public GameObject healthBar;
    private float iFrames = 0;

    // Update is called once per frame
    void Update()
    {
        if (iFrames != 0)
        {
            iFrames -= Time.deltaTime;
            if (iFrames < 0)
            {
                iFrames = 0;
            }
        }
    }

    // Method to be called by projectile that makes the player take damage according to the spell
    public void loseHealth(int projDamage)
    {
        if (iFrames <= 0)
        {
            health -= projDamage;
            iFrames = .25f;
            healthBar.GetComponent<HealthBar>().UpdateHealth(health);
        }
        if (health <= 0 )
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Death Screen");
        }
    }

}
