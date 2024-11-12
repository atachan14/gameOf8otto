using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    Vector3 direction;
    public float speed = 0.5f;
    int count = 1200;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction*speed;
        count--;
        if(count==0) Destroy(gameObject);
    }

    public void setDirection(Vector3 vector)
    {
        direction = vector;
    }
}
