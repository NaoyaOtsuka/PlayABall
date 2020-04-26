using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleArea : MonoBehaviour
{
    public Vector3 playerStartPos;
    private void Start()
    {
        playerStartPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
    }
    private void OnTriggerExit(Collider other)
    {
        //複数が同時にエリア外に出た場合どうなる？
        //増えるようならSwitchで書いたほうがいい
        if (other.tag == "Untagged") return;
        Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();

        if (other.tag == "Enemy")
        {
            //Destroy(other.gameObject);
        }

        if (other.tag == "Player")
        {
            other.gameObject.transform.position = playerStartPos;
        }
    }
}
