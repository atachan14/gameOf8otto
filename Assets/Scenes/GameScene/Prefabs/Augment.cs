using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Augment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exe()
    {
        EventManager.Instance.AugmentTimeSpeedExe();
        Debug.Log("Augment.Exe end");
    }
}
