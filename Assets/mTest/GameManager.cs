using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    int flameCount = 0;
    int secCount = 0;
    public GameObject lifePrefab;
    public GameObject tamaPrefab ;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        flameCounts();

        if (secCount == 10) sec10();
        
    }

    void flameCounts()
    {
        flameCount++;
        if (flameCount == 60) secCount++;
    }

    void sec10()
    {
        Instantiate(tamaPrefab, new Vector3(20, -1, 0), Quaternion.identity);

    }
}
