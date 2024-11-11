using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kuppaController : MonoBehaviour
{

    public int fireTriggerSec = 20;
    public int fireSec = 4;
    public Vector3 fireSpawnPos = new Vector3(0, -1, 0);
    public GameObject firePrefab;

    int framelate;
    Transform parentTransform;
    int count = 0;
    bool isFire;

    // Start is called before the first frame update
    void Start()
    {
        framelate = Application.targetFrameRate;
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        fireTriger();
        fireTriger();

    }

    void fireTriger()
    {
        if (count % fireTriggerSec * 60 == 0)
        {
            isFire = Random.Range(0f, 1f) > 0.5F;
        }


    }

    void fire()
    {
        if (isFire)
        {
            if (count == fireSec)
            {

                Instantiate(firePrefab, fireSpawnPos, Quaternion.identity, parentTransform);
            }
        }
    }
}
