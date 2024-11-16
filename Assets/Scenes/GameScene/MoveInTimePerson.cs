using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInTimePerson : MonoBehaviour
{
    private float TimeSpeed = 1f;
    public Vector3 MoveVector = new Vector3();

    GameManager manager;
    // Start is called before the first frame update

    private void Awake()
    {
        EventManager.Instance.OnTimeSpeedChanged += TimeSpeedChanged;
    }
    void Start()
    {
    }

    void Update()
    {
    }

    public void MoveInTime()
    {
        transform.position = MoveVector* TimeSpeed;
    }

    public virtual void TimeSpeedChanged(float timeSpeed, float keepTime)
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
