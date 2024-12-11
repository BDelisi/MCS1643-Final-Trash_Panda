using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.LowLevel;

public class BatBehavior : MonoBehaviour
{
    public GameObject target;
    public float attackRange = 1f;
    public AudioSource attack;
    public GameObject projectile;
    private NavMeshAgent agent;
    private float movingCd;
    private GameObject player;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<FirstPersonController>().gameObject;
        target = player;
        agent.destination = target.transform.position;
    }

    void FixedUpdate()
    {
        //tells the NavMesh to pathfind towards the target
        if (movingCd == 0)
        {
            agent.destination = target.transform.position;
            if (Vector3.Distance(transform.position, target.transform.position) <= attackRange)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, target.transform.position - transform.position, out hit))
                {
                    if (hit.transform == target.transform)
                    {
                        GameObject temp = Instantiate(projectile, transform.position + transform.rotation * new Vector3(0, 0, 1f), transform.rotation);
                        temp.transform.LookAt(player.transform.position + new Vector3(0, .85f, 0));
                        temp.GetComponent<Projectile>().straightShot();
                        movingCd = Random.Range(1f,3f);
                        attack.Play();
                    }
                }
                agent.destination = transform.position;
            }
        }
        else
        {
            movingCd -= Time.deltaTime;
            agent.destination = transform.position;
            if (movingCd < 0)
            {
                movingCd = 0;
            }
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player") && movingCd <= 0)
    //    {
    //        collision.gameObject.GetComponent<Player>().loseHealth(1);
    //        movingCd = .5f;
    //    }
    //}
}
