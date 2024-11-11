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
        float randomY = Random.Range(mainCamera.ViewportToWorldPoint(new Vector3(0, 0, spawnDistance)).y,
                                     mainCamera.ViewportToWorldPoint(new Vector3(0, 1, spawnDistance)).y);
        
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward * spawnDistance;
        spawnPosition.y = randomY + 1f;

        Instantiate(prefab, spawnPosition, Quaternion.identity);
    }
}
