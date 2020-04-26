using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeTrail : MonoBehaviour
{
    public float time = 1f;
    private Rigidbody rb;
    private SphereCollider sphere;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (sphere = GetComponent<SphereCollider>()) return;
        gameObject.AddComponent<SphereCollider>();
        sphere = GetComponent<SphereCollider>();
    }

    void FixedUpdate()
    {
        Debug.Log(AfterPosition(rb.position, rb.velocity, time));
    }
    Vector3 AfterPosition(Vector3 startPos, Vector3 direction, float time)
    {
        if (time == 0) return startPos;
        
        Debug.DrawRay(startPos, direction * time, Color.red, 1f);
        RaycastHit hit;
        var distance = direction.magnitude;
        if (!Physics.SphereCast(startPos, sphere.radius, direction, out hit, time))  return startPos * time;

        time =  (direction * time).magnitude - (hit.point - startPos).magnitude;
        time /= direction.magnitude;
        var reflectVec = Vector3.Reflect(direction, hit.normal) * time;

        Debug.DrawRay(hit.point, reflectVec * time, Color.blue, 1f);
        return reflectVec * time;
    }
}
