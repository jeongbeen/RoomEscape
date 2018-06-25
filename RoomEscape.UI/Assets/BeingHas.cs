using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BeingHas : MonoBehaviour
{

    public SphereCollider sphereCollider;
   
    bool PlayerIn;
    // Use this for initialization
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);
        PlayerIn = true;
    }
    public void OnCollisionExit(Collision collision)
    {
        PlayerIn = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && PlayerIn)
        {
            transform.parent = GameObject.Find("Player").transform;
            Debug.Log("Flashlight");
            transform.localPosition = new Vector3(0.5f,0.5f,0.5f);
            sphereCollider.enabled = false;




        }



    }

    

}
