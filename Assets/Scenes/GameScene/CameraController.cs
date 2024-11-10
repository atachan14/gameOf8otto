using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraSpeed = 10 / 60f;
    public GameObject player;
    public float yOffset;
    public float yDefault;
    public float yUpAria;
    public float yDownAria;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        nextPos.x += cameraSpeed;

        //if (player.transform.position.y > yDefault + yUpAria)
        //{
            nextPos.y = Mathf.Lerp(transform.position.y, player.transform.position.y + yOffset, 0.1f);
        //}
        //else if (player.transform.position.y < yDefault - yDownAria)
        //{
        //    nextPos.y = Mathf.Lerp(player.transform.position.y, yUpAria + yOffset,0.1f);
        //}
        //else
        //{
        //    nextPos.y = yDefault;
        //}
        transform.position = nextPos;
    }
}
