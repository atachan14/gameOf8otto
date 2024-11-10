using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSetUp : MonoBehaviour
{
    public Camera mainCamera;  // ���C���J����
    public GameObject leftWall;   // ����

    void Start()
    {
        // �J�����̃r���[�͈͂��擾
        float cameraHeight = 2f * mainCamera.orthographicSize;  // �J�����̍���
        float cameraWidth = cameraHeight * mainCamera.aspect;  // �J�����̕�

        // ���ǂƉE�ǂ̈ʒu�𒲐�
        leftWall.transform.position = new Vector3((mainCamera.transform.position.x - cameraWidth / 2) + 2, mainCamera.transform.position.y, 0);
    }
    void Update()
    {
        // �J�����̃r���[�͈͂��擾
        float cameraHeight = 2f * mainCamera.orthographicSize;  // �J�����̍���
        float cameraWidth = cameraHeight * mainCamera.aspect;  // �J�����̕�

        // ���ǂƉE�ǂ̈ʒu�𒲐�
        leftWall.transform.position = new Vector3((mainCamera.transform.position.x - cameraWidth / 2) + 2, mainCamera.transform.position.y, 0);
    }
}