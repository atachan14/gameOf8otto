using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float StartTime { get; set; }
    GameObject mainCamera;
    CameraController camecon;
    // Start is called before the first frame update
    void Start()
    { 
        Application.targetFrameRate = 60;
        Time.timeScale = 1;
        camecon = mainCamera.GetComponent<CameraController>();
        StartCoroutine(TriggerOnceAfterDelay(9f));
        StartCoroutine(TriggerOnceAfterDelay(16f));
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator TriggerOnceAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        switch (delay)
        {
            case 9f:
                StartCoroutine(camecon.addCameraSpeedOverTime(0f, 1f, 7f));
                break;
            case 16f:
                StartCoroutine(camecon.addCameraSpeedOverTime(0f, camecon.GetCameraBaseSpeed(), 1f));
                break;
        }
    }
}
