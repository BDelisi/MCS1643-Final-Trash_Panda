using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoldenSpoon : MonoBehaviour
{
    bool goingUp = true;
    public float vertSpeed = 0.1f;
    float x, z;
    // Update is called once per frame

    void Start()
    {
        x = transform.position.x; 
        z = transform.position.z;
    }
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(-.3f, Vector3.up);
        if (goingUp /* on a tuesday */)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, 2.5f, z), vertSpeed * Time.deltaTime);
            if (transform.position.y == 2.5f)
            {
                goingUp = false;
            }
        } else if (goingUp == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, 1.3f, z), vertSpeed * Time.deltaTime);
            if (transform.position.y == 1.3f)
            {
                goingUp = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Win Scene");   
        }
    }
}
