using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    private GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.LookRotation(MainCamera.transform.position - transform.position);
    }
}
