using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public KeyCode shoot;
    public GameObject projectile;
    private float cooldown;
    public BoxCollider hitDetection;
    public List<GameObject> enemiesToShoot = new List<GameObject>();

    private void Start()
    {
        hitDetection = GetComponent<BoxCollider>();

    }

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
                GameObject temp = Instantiate(projectile, transform.position + transform.rotation * new Vector3(0, .65f, 1f), transform.rotation);
                temp.GetComponent<Projectile>().straightShot();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesToShoot.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemiesToShoot.Remove(other.gameObject);
        }
    }
}
