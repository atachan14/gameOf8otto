using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuppa : MoveInTimePerson
{

    public int fireTriggerSec = 16;
    public int fireSec = 4;
    public Vector3 fireSpawnPos = new Vector3(-1, 0, 0);
    public GameObject firePrefab;

    GameObject fireParentObject;
    bool isFire = false;
    float nextFireTriggerTime = 0f;
    float nextFireTime = 0f;
    Vector3 fireDirection = new Vector3(-1, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        nextFireTriggerTime = Time.time + fireTriggerSec;

        fireParentObject = GameObject.Find("map");

    }

    // Update is called once per frame
    void Update()
    {
        fireTrigger();
        if (isFire) fire();
    }

    void fireTrigger()
    {
        if (Time.time >= nextFireTriggerTime)
        {
            isFire = Random.Range(0f, 1f) > 0.5F;
            nextFireTriggerTime = Time.time + fireTriggerSec;
        }
    }

    void fire()
    {
        if (Time.time >= nextFireTime)
        {
            GameObject newFireObject = Instantiate(firePrefab, transform.position + fireSpawnPos, Quaternion.identity, fireParentObject.transform);
            newFireObject.GetComponent<fire>().setDirection(fireDirection);

            nextFireTime = Time.time + fireSec;
        }
    }
}
