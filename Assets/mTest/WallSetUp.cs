using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSetUp : MonoBehaviour
{
    public Camera mainCamera;  // メインカメラ
    public GameObject leftWall;   // 左壁

    void Start()
    {
        // カメラのビュー範囲を取得
        float cameraHeight = 2f * mainCamera.orthographicSize;  // カメラの高さ
        float cameraWidth = cameraHeight * mainCamera.aspect;  // カメラの幅

        // 左壁と右壁の位置を調整
        leftWall.transform.position = new Vector3((mainCamera.transform.position.x - cameraWidth / 2) + 2, mainCamera.transform.position.y, 0);
    }
    void Update()
    {
        // カメラのビュー範囲を取得
        float cameraHeight = 2f * mainCamera.orthographicSize;  // カメラの高さ
        float cameraWidth = cameraHeight * mainCamera.aspect;  // カメラの幅

        // 左壁と右壁の位置を調整
        leftWall.transform.position = new Vector3((mainCamera.transform.position.x - cameraWidth / 2) + 2, mainCamera.transform.position.y, 0);
    }
}