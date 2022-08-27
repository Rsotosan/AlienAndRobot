using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenTheDayIsOver : MonoBehaviour
{

    [SerializeField]
    GameObject textBoxBeforeChangingScene;

    TextController textScript;
    // Start is called before the first frame update
    void Start()
    {
        textScript = GetComponent<TextController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (LightingManager.isDayFinished)
        {
            textBoxBeforeChangingScene.SetActive(true);
            textScript.enabled = true;
        }
    }   
}