using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float StartTime { get; set; }
    private float TimeSpeed { get; set; } = 1;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public static GameManager Instance { get; private set; }


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        StartTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

    }






}
