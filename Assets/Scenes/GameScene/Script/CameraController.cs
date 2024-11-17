using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float cameraBaseSpeed;
    public GameObject player;
    public float yOffset;
    public float yDefault;
    public float yUpAria;
    public float yDownAria;

    private float cameraActualSpeed;

    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraActualSpeed = cameraBaseSpeed;
        nextPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        nextPos.x += cameraActualSpeed * Time.timeScale;
        nextPos.y = Mathf.Lerp(transform.position.y, player.transform.position.y + yOffset, 0.1f);
        transform.position = nextPos;
    }

    public IEnumerator addCameraSpeedOverTime(float startSpeed, float endSpeed, float duration)
    {
        Debug.Log("cameraSpeed kidou: " + cameraActualSpeed);
        float elapsedTime = 0f;
        cameraActualSpeed = startSpeed;

        while (elapsedTime < duration)
        {
            cameraActualSpeed += Mathf.Lerp(startSpeed, endSpeed, elapsedTime / duration);
            elapsedTime += Time.unscaledDeltaTime;
            yield return null;
        }

        cameraActualSpeed = endSpeed;

        Debug.Log("cameraSpeed ‚ª–Ú•W’l‚É“ž’B‚µ‚Ü‚µ‚½: " + cameraActualSpeed);
    }

    public float GetCameraBaseSpeed()
    {
        return cameraBaseSpeed;
    }
}
