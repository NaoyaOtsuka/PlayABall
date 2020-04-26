using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    //Collider col;
    private void Start() {
        
       //col = GetComponent<MeshCollider>();
    }
    Rigidbody rb;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
        }

        if (other.gameObject.tag == "Enemy")
        {
            rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb.velocity.magnitude < 30)
            {
                Collider col = other.gameObject.GetComponent<Collider>();
                //col.enabled = false;
            }
        }
    }
}
