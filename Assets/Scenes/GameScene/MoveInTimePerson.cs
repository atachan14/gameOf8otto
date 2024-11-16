using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInTimePerson : MonoBehaviour
{
    private float ActualSpeed;
    public float ConstantSpeed;
    public float TimeSpeed = 1f;
    GameManager manager;
    // Start is called before the first frame update

    void Start()
    {
        ActualSpeed = ConstantSpeed;
        EventManager.Instance.OnTimeSpeedChanged += TimeSpeedChanged;
    }

    void Update()
    {
       ActualSpeed = ConstantSpeed * TimeSpeed;
    }

    public void TimeSpeedChanged(float timeSpeed,float keepTime)
    {
        Debug.Log("MoveInTimePerson TimeSpeedChanged");
        float startTime = Time.time;
        TimeSpeed = timeSpeed;
        if (Time.time > startTime + keepTime)
        {
            TimeSpeed = 1;
        }


    }

    
}
