using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode shoot;
    public GameObject projectile;
    private float cooldown;
    // Update is called once per frame
    void Update()
    {
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

                Instantiate(projectile);
                cooldown = 2;
            }
        }
    }
     
    
}
