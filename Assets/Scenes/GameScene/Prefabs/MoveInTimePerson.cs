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
    }

    void Update()
    {
        this.TimeSpeed = manager.GetTimeSpeed();
        ActualSpeed = ConstantSpeed * TimeSpeed;
    }

    
}
