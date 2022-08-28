using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float force;
    [SerializeField] private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
    }

    void MovePlayer() {
        var vInput = Input.GetAxis("Vertical");
        var hInput = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * hInput * Time.fixedDeltaTime * rotationSpeed);

        rb.AddForce(this.transform.forward * force * vInput, ForceMode.Force);
    }
}
