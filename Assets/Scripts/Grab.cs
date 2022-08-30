using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public float range = 5f;
    public float moveForce = 150f;
    public Transform holdParent;
    private GameObject heldObj;

    void Update() {
        DetectHit();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void DetectHit()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            // Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.magenta, range);
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
                {
                    if (hit.transform.gameObject.tag == "Robot")
                    {
                        PickupObject(hit.transform.gameObject);
                    }
                }
            }
            else
            {
                DropObject();
            }
        }

    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject obj)
    {
        if (obj.GetComponent<Rigidbody>())
        {
            var objRb = obj.GetComponent<Rigidbody>();
            objRb.useGravity = false;
            objRb.drag = 10;

            objRb.transform.parent = holdParent;
            heldObj = obj;
        }
    }

    void DropObject()
    {
        if (heldObj != null)
        {
            var heldRb = heldObj.GetComponent<Rigidbody>();
            heldRb.useGravity = true;
            heldRb.drag = 1;

            heldObj.transform.parent = null;
            heldObj = null;

        }
    }
}
