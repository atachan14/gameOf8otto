using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject player;            // Player�I�u�W�F�N�g�ւ̎Q��

    private PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerScript = player.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + playerScript.GetScore() + "\nTime : " + Time.time.ToString("F2");
    }
}
