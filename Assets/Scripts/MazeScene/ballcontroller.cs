using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballcontroller : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(0.008f * Physics.gravity);
    }

}
