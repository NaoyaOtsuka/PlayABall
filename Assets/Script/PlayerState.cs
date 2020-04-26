using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerState : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotateSpeed = 0.1f;
    public Vector3 originOffset = new Vector3(0f, 0.9f, 0f);
    public float sphereRadius = 0.35f; // 小さくしすぎると計算誤差で接地判定が取れない
    private Vector3 cursorPos;
    //private Collider col;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        IsAttacking();
        IsControlling();
    }

    bool IsControlling()
    {
        if (rb.velocity.magnitude > 0.1f) return false;
        return true;
    }

    bool IsAttacking()
    {
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Enemy") return;
        agent.enabled = false;

        Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();


        if (otherRb.velocity.magnitude == 10f)
        {
            Debug.Log("Ouch!");
        }
        else
        {
            //Debug.Log("Nop");
            rb.velocity = Vector3.zero;
            //Debug.Log(rb.velocity);
        }
    }
}
