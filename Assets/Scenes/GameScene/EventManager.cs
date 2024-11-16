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
        Debug.Log("EventManager Instance is set");
    }

    public event Action<float,float> OnTimeSpeedChanged;

    public void TriggerTimeSpeedChanged(float newSpeed,float keepTime)
    {
       Debug.Log($"OnTimeSpeedChanged listener count: {OnTimeSpeedChanged?.GetInvocationList().Length ?? 0}");

        OnTimeSpeedChanged?.Invoke(newSpeed,keepTime);

    }

    public void AugmentTimeSpeedExe()
    {
        Debug.Log("Subscribing to OnTimeSpeedChanged");
        EventManager.Instance.TriggerTimeSpeedChanged(0f, 2f);
        StartCoroutine(Helper.Wait(2f));
        EventManager.Instance.TriggerTimeSpeedChanged(0.5f, 2f);

    }

}
