using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    // Controls projectile speed
    public float projectileSpeed = 1f;

    // target game object for when player is aiming at a specific enemy
    private GameObject trackingTarget;


    // This is called f
    void Update() 
    {
        if (trackingTarget != null)
        {
            trackingProj();
        }

    }

    //Method called after projectile instantiated in player class,
    //determines if whether to fire projectile straight or track onto enemy 
    public void startProj(GameObject receiver)
    {
        if (receiver == null)
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
        } else
        {
            trackingTarget = receiver; 
        }
    }

    //Tells projectile to track to its target and move to that pos
    public void trackingProj()
    {
        transform.position = Vector3.MoveTowards(transform.position, trackingTarget.transform.position, projectileSpeed * Time.deltaTime);
    }


}
