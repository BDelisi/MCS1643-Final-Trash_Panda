using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private GameObject MainCamera;
    
    void Start()
    {
        MainCamera = Camera.main.gameObject;
    }

    void Update()
    {
        //Makes the sprite always face towards the camera
        transform.rotation = Quaternion.LookRotation(MainCamera.transform.position - transform.position);
    }
}
