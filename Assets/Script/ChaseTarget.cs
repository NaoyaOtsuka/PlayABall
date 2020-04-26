using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseTarget : MonoBehaviour
{
    //ターゲットが更新されたりすると面白いかもしれない
    //例：仲間を攻撃するようになったり
    public Transform target;
    public float speed = 50f;
    private Rigidbody rb;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.3f);
        //transformではなくRigidbody.AddForceで物理ベースで移動すると加速度とかがいい感じに
        //補完されて気持ちがいい
        //今の設定だとジェット噴射してるみたいになってしまうので転がっていくような挙動にする必要がある
        //Quartanionの計算で決定したFowardの方向をXZ平面にのみ適用できるようにする必要がある
        rb.AddForce(transform.forward * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player") return;
        //Destroy(this.gameObject);
    }
}
