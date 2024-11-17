using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoresPerant : MonoBehaviour
{
    public int score;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public int getScore()
    {
        return score;
    }

    public void destroyExe()
    {
        Destroy(this.gameObject);
    }
}
