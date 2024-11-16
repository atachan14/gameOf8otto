using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public event Action<float,float> OnTimeSpeedChanged;

    public void TriggerTimeSpeedChanged(float newSpeed,float keepTime)
    {
        Debug.Log("trigger toota?");
        OnTimeSpeedChanged?.Invoke(newSpeed,keepTime);
    }

    public void AugmentTimeSpeedExe()
    {
        EventManager.Instance.TriggerTimeSpeedChanged(0f, 2f);
        StartCoroutine(Helper.Wait(2f));
        EventManager.Instance.TriggerTimeSpeedChanged(0.5f, 2f);

    }

}
