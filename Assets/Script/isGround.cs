using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isGround : MonoBehaviour
{
    public Vector3 origin = new Vector3(0f, 0.0f, 0f);
    public float sphereRadius = 0.1f;
    public float rayDistance = 0.1f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 rayDirection = transform.up * -1f;
        //float rayDistance = origin.y - sphereRadius;
        origin = transform.position;
        Debug.Log(Physics.SphereCast(origin, sphereRadius, rayDirection, out hit, rayDistance));
    }
}
