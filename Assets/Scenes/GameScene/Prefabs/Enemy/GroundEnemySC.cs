using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemySC : MoveInTimePerson
{
    public float speed = 0.2f;
    public int atk = 10;
    GameObject target = null;
    Vector3 targetDirectionX = new Vector3(0f, 0f, 0f);


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
           if(target.transform.position.x < transform.position.x) targetDirectionX=Vector3.left;
            transform.position += targetDirectionX * speed;
        }
    }

    public void FoundPlayer(GameObject player)
    {
        target = player;
    }

    public void HitPlayer(GameObject player)
    {
        target = player;
    }

    public int GetAtk()
    {
        return atk;
    }
}
