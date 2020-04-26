using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public List<GameObject> myList = new List<GameObject>();

    void Start()
    {
        myList.Add(GameObject.FindGameObjectWithTag("Player"));
        myList.Add(GameObject.FindGameObjectWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Creature : MonoBehaviour
{
    public GameObject obj;
    public float health;

    public Creature(float health)
    {
        this.health = health;
    }
}
