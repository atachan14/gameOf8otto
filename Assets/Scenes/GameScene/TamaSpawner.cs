using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TamaSpawner : MonoBehaviour
{
    public GameObject prefab; 
    public float spawnInterval = 2f; 
    private Camera mainCamera;
    public float spawnDistance = 5f;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("GeneratePrefab", 0f, spawnInterval);
    }


    void GeneratePrefab()
    {
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;
        
        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
