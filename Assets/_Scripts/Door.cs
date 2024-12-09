using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool closeOnExit = false;
    public float openSpeed = 1f;
    public float closeDelay = 1f;
    bool isOpen = false;
    bool doorClosing = false;

    GameObject grate;

    //Declares origPos V3 (so it can store origPos)
    Vector3 origPos;
    Vector3 targPos;

    void Start()
    {
        grate = transform.GetChild(0).gameObject;
        origPos = grate.transform.position;
        targPos = new Vector3(grate.transform.position.x, grate.transform.position.y + 2, grate.transform.position.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        //Door closing controls the delay between invoke and movetowards so if the player reenters the collider during that delay, the door wont close
        doorClosing = false;
        Debug.Log("Trigger works");
        if (other.CompareTag("Player") && isOpen == false)
        {
            Debug.Log("Door up");
            while (targPos.y > grate.transform.position.y)
            {
                grate.transform.position = Vector3.MoveTowards(grate.transform.position, targPos, openSpeed * Time.deltaTime);
            }
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && closeOnExit && isOpen)
        {
            doorClosing = true;
            Invoke("closeAfterDelay", closeDelay);
            isOpen = false;
        }
    }

    void closeAfterDelay()
    {
        if (doorClosing)
        {
            while (origPos.y < grate.transform.position.y)
            {
                grate.transform.position = Vector3.MoveTowards(grate.transform.position, origPos, openSpeed * Time.deltaTime);
            }
        }
    }

}
