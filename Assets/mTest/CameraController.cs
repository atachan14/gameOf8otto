using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float cameraSpeed = 10/60f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * cameraSpeed;
    }
}
