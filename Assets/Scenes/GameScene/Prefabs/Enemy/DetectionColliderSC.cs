using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionColliderSC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        GetComponentInParent<EnemySC>().FoundPlayer(collision.gameObject);
        Debug.Log("OntriggerEnter2D end");
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
            GetComponentInParent<EnemySC>().FoundPlayer(null);
        Debug.Log("OntriggerExit2D end");
    }
}
