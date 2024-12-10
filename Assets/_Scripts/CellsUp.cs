using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellsUp : MonoBehaviour
{
    public AudioClip open;
    bool runOnce = true;

    private void OnTriggerEnter(Collider other)
    {
        if (runOnce && other.CompareTag("Player"))
        {
            doorOpen();
            Invoke("doorOpen", .25f);
            Invoke("doorOpen", .5f);
            Invoke("doorOpen", .75f);
            Invoke("doorOpen", 1.0f);
            Invoke("doorOpen", 1.25f);
            Invoke("doorOpen", 1.5f);

            runOnce = false;
        }
    }

    void doorOpen()
    {
        AudioSource.PlayClipAtPoint(open, new Vector3(-19, 2, -5.5f));
    }


}