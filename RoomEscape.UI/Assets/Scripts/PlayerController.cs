using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) == true)
        {
            transform.Rotate(-Vector3.up * Time.deltaTime * speed * 10);
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            transform.Rotate(Vector3.up * Time.deltaTime * speed * 10);
        }
        if (Input.GetKey(KeyCode.W) == true)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
    }
}