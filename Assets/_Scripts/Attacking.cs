using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Attacking : MonoBehaviour
{
    public KeyCode shoot;
    public GameObject projectile;
    public float shotCooldown = 1f;
    public List<GameObject> enemiesToShoot = new List<GameObject>();
    private float cooldown;
    private BoxCollider hitDetection;

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
                cooldown = shotCooldown;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject temp = Instantiate(projectile, transform.position + transform.rotation * new Vector3(0, .65f, 1f), transform.rotation);
        if (enemiesToShoot.Count == 0)
        {
            temp.GetComponent<Projectile>().straightShot();
        }
        else
        {
            float distance = Vector3.Distance(enemiesToShoot[0].transform.position, transform.position);
            GameObject target = enemiesToShoot[0];
            for (int i = 0; i < enemiesToShoot.Count; i++)
            {
                float tempDistance = Vector3.Distance(enemiesToShoot[i].transform.position, transform.position);
                if (distance > tempDistance)
                {
                    distance = tempDistance;
                    target = enemiesToShoot[i];
                }
            }
            temp.GetComponent<Projectile>().setTarget(target);
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
            enemiesToShoot.Remove(other.transform.gameObject);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemiesToShoot.Remove(enemy);
    }
}
