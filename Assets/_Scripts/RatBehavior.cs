using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class RatBehavior : MonoBehaviour
{
    public GameObject target;
    public int damage = 1;
    private NavMeshAgent agent;
    private float movingCd;
    private GameObject player;
    private Animator animations;
    private Vector3 lastPos;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<FirstPersonController>().gameObject;
        target = player;
        agent.destination = target.transform.position;
        animations = GetComponent<Animator>();
        lastPos = transform.position;
    }

    private void Update()
    {
        animations.SetFloat("currentSpeed", Vector3.Distance(transform.position, lastPos) * Time.deltaTime);
        lastPos = transform.position;
    }

    void FixedUpdate()
    {
        //tells the NavMesh to pathfind towards the target
        if (movingCd == 0)
        {
            agent.destination = target.transform.position;
            
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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && movingCd <= 0)
        {
            collision.gameObject.GetComponent<Player>().loseHealth(damage);
            movingCd = .5f;
        }
    }
}
