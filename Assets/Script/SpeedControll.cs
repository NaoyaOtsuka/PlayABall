using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TakashiCompany.Unity.Util;

public class SpeedControll : MonoBehaviour
{
    private Rigidbody rb;
    public float maxMagnitude = 34f;
    public Vector3 postPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxMagnitude);

        var time = 1f;
        postPosition = TrajectoryCalculate.Force(transform.position, rb.velocity, rb.mass, Physics.gravity, 1, time);
    }
}
