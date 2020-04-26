using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    private Rigidbody rb;
    public string owner;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == owner) return;
        //gameObject.tag = "";
        //var dir = Vector3.Normalize(other.gameObject.transform.position - transform.position);
        var otherRb = other.GetComponent<Rigidbody>();

        if(rb.velocity.magnitude > 20)
        {
            otherRb.velocity = rb.velocity;
        }
    }
}
