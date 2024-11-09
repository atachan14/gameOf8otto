using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerScript player; // PlayerScript�̎Q��
    public GameObject lifePrefab; // ���C�t�̕\���pPrefab
    private List<GameObject> lifeIcons = new List<GameObject>(); // ���C�t�A�C�R���̃��X�g

    // Start is called before the first frame update
    void Start()
    {
        UpdateLifeDisplay(player.getLife()); // �������C�t�\����ݒ�
    }

    // �v���C���[�̃��C�t���ς�����Ƃ��ɌĂяo�����\�b�h
    public void UpdateLifeDisplay(int life)
    {
        // �����̃��C�t�A�C�R�������ׂč폜
        foreach (var icon in lifeIcons)
        {
            Destroy(icon);
        }
        lifeIcons.Clear();

        // �V�������C�t�A�C�R����\��
        Vector3 lifeDisplayStart = new Vector3(0, 0, 0); // �\���J�n�ʒu
        for (int i = 0; i < life; i++)
        {
            GameObject icon = Instantiate(lifePrefab, lifeDisplayStart + Vector3.right * i, Quaternion.identity, transform);
            lifeIcons.Add(icon); // �A�C�R�������X�g�ɒǉ�
        }
    }
}