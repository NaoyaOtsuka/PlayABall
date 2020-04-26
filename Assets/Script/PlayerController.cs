using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public float rotateSpeed = 0.1f;
    public Vector3 originOffset = new Vector3(0f, 0.9f, 0f);
    public float sphereRadius = 0.35f; // 小さくしすぎると計算誤差で接地判定が取れない
    private float v;
    private float h;
    private Vector3 cursorPos;
    private Vector3 movement = new Vector3();
    //private Collider col;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private Animator animator;
    public bool LockOnEnable = false;
    public Transform enemy;

    void Start()
    {
        animator = GetComponent<Animator>();
        //col = GameObject.FindGameObjectWithTag("Damage").GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
    }
    void FixedUpdate()
    {
        //if (col.enabled == true) col.enabled = false;
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
        //rb.isKinematic = true;
        agent.enabled = true;

        Move();

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
            //col.enabled = true;
        }

        if (Input.GetKeyDown("left shift"))
        {
            if (LockOnEnable == false)
            {
                LockOnEnable = true;
            }
            else
            {
                LockOnEnable = false;
            }
        }

        PlayerLookAt();
    }

    public float preTheta = 0f;
    void Move()
    {
        v = Input.GetAxis("Vertical");
        h = Input.GetAxis("Horizontal");

        float theta = transform.localEulerAngles.y;
        float rad = theta * Mathf.Deg2Rad;
        float sin = Mathf.Sin(rad);
        float cos = Mathf.Cos(rad);
        float side = cos * h + sin * v;
        float forward = sin * h + cos * v;
        animator.SetFloat("X", side);
        animator.SetFloat("Z", forward);

        movement.Set(h, 0f, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;
        agent.Move(movement);

        //その場で回転
        Vector3 r = new Vector3(0f, theta - preTheta, 45f);
        r = r.normalized;
        animator.SetFloat("Turn", r.y);
        preTheta = theta;
    }

    void PlayerLookAt()
    {
        if (LockOnEnable == true)
        {
            cursorPos = enemy.position;
        }
        else
        {
            cursorPos.Set(Input.mousePosition.x, Input.mousePosition.y, 10f);
            cursorPos = Camera.main.ScreenToWorldPoint(cursorPos);
        }

        Quaternion lookRotation = Quaternion.LookRotation(cursorPos - transform.position, Vector3.up);
        lookRotation.z = 0;
        lookRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, rotateSpeed);
    }
}
