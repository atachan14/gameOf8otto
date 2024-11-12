using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int frameCount = 0;
    int secCount = 0;
   
    public GameObject daiyaPrefab ;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        frameCounts();
        if (frameCount == 100) frame100();
    }

    void frameCounts()
    {
        frameCount++;
        if (frameCount%60 == 0) secCount++;
    }

    void frame100()
    {
        Instantiate(daiyaPrefab, new Vector3(110, -1, 0), Quaternion.identity);
    }

   
}
