using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatBehavior : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;
    }

   
    void FixedUpdate()
    {
        agent.destination = target.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

        }
    }
}
