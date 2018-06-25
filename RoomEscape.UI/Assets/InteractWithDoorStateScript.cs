using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithDoorStateScript : MonoBehaviour
{

    public float interactDistance = 5f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.transform.GetComponent<DoorState>().ChangeDoorState();
                }
                ///if(hit.collider.CompareTag("Flashlight"))
                ///{
                ///    hit.collider.transform.GetComponent<BeingHas>().ChangeState();
                ///}
            }
        }
    }
}
