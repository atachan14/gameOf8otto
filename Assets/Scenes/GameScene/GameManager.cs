using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float startTime;
    private float TimeSpeed = 1;
            
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        startTime =Time.time;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void setTimeSpeed(float timeSpeed)
    {
        TimeSpeed = timeSpeed;
    }

    public float GetTimeSpeed()
    {
        return TimeSpeed;
    }

   

   
}
