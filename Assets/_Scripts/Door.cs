using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool closeOnExit = false;
    public int openSpeed = 1;

    //Declares origPos V3 (so it can store origPos)
    Vector3 origPos;

    void Start()
    {
        origPos = transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.position = Vector3.MoveTowards(origPos, new Vector3(transform.position.x, transform.position.y + 3, transform.position.z), openSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && closeOnExit)
        {
            transform.position = Vector3.MoveTowards(transform.position, origPos, openSpeed * Time.deltaTime);
        }
    }

    
}
