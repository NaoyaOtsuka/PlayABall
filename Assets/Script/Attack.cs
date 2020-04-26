using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float mult;
    public float startMult;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Ball") return;

        var rb = other.GetComponent<Rigidbody>();

        if (rb.velocity.magnitude < 10f)
        {
            rb.velocity = transform.forward * startMult;
            return;
        }
        else
        {
            rb.velocity = transform.forward * rb.velocity.magnitude * mult;
        }
    }
}
