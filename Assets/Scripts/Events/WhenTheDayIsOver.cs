using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenTheDayIsOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LightingManager.isDayFinished)
        {
            Debug.Log("THE DAY HAS FINISHED");
        }
    }
}
