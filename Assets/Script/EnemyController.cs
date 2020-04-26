using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TakashiCompany.Unity.Util;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotateSpeed = 0.1f;
    public Vector3 originOffset = new Vector3(0f, 0.9f, 0f);
    public float sphereRadius = 0.35f; // 小さくしすぎると計算誤差で接地判定が取れない
    //private Collider col;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private Animator animator;
    public Transform target;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        RaycastHit hit;
        float rayDistance = transform.position.y + originOffset.y - sphereRadius;
        if (!Physics.SphereCast(transform.position + originOffset, sphereRadius, Vector3.down, out hit, rayDistance))
        {
            Debug.Log(transform.position.y + originOffset.y);
            Debug.Log(rayDistance + sphereRadius);
            Debug.Log(Physics.SphereCast(transform.position + originOffset, sphereRadius, Vector3.down, out hit, rayDistance));
        }
        //if (!Physics.SphereCast(transform.position + originOffset, sphereRadius,  Vector3.down, out hit, rayDistance)) return;

        if (rb.velocity.magnitude > 0.1f) return;
        rb.velocity = Vector3.zero;
        agent.enabled = true;

        


        Move(target.position);

        if (false)
        {
            //animator.SetTrigger("Attack");
        }

        LookAt(target.position);
    }

    public float preTheta = 0f;
    void Move(Vector3 position)
    {
        agent.SetDestination(position);
        float h =agent.velocity.x;
        float v =agent.velocity.z;

        float theta = transform.localEulerAngles.y;
        float rad = theta * Mathf.Deg2Rad;
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);
        float side = cos * h + sin * v;
        float forward = sin * h + cos * v;
        animator.SetFloat("X", side);
        animator.SetFloat("Z", forward);
        
        //その場で回転
        Vector3 r = new Vector3(0f, theta - preTheta, 45f);
        r = r.normalized;
        animator.SetFloat("Turn", r.y);
        preTheta = theta;
    }

    void LookAt(Vector3 position)
    {
        Quaternion lookRotation = Quaternion.LookRotation(position - transform.position, Vector3.up);
        lookRotation.z = 0;
        lookRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotateSpeed);
    }
}
