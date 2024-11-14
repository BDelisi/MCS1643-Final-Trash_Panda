using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RatBehavior : MonoBehaviour
{
    public GameObject target;
    private NavMeshAgent agent;
    private bool attacking;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.transform.position;
    }

   
    void FixedUpdate()
    {
        //tells the NavMesh to pathfind towards the target
        agent.destination = target.transform.position;
    }
}
