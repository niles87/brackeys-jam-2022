using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col) {
        if (col.CompareTag("Robot")) {
            Debug.Log(col.gameObject.tag);
        }
    }

    void OnTriggerStay(Collider col) {
        if (col.CompareTag("Robot")) {
            if (Input.GetKey(KeyCode.G)) {
                Debug.Log("Grabbing "+ col.gameObject.tag);
            }
        }
    }
}
