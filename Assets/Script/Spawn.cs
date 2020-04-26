using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("h"))
        {
            SpawnSphere();
        }
    }

    void SpawnSphere()
    {
        GameObject Sphere = (GameObject)Resources.Load ("Sphere");
        Sphere = GameObject.Instantiate(Sphere,transform.position, transform.rotation);
        /*
        GameObject Sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        Sphere.AddComponent<Rigidbody>();
        Sphere.transform.localScale = new Vector3(1f,1f,1f);
        Rigidbody rb = Sphere.GetComponent<Rigidbody>();
        rb.mass = 0.3f;
        SphereCollider sc =Sphere.GetComponent<SphereCollider>();
        */
        Sphere.tag = "Enemy";
        //Sphere.AddComponent<ChaseTarget>();
    }
}
