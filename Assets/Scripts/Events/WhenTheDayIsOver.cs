using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenTheDayIsOver : MonoBehaviour
{

    [SerializeField]
    GameObject textBoxBeforeChangingScene;

    TextController textScript;

    bool firstTime = false;
    // Start is called before the first frame update
    void Start()
    {
        textScript = GetComponent<TextController>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (LightingManager.isDayFinished && !firstTime)
        {
            firstTime = true;
            Debug.Log("Total " + BabanosUI.babanoTotal);

            BabanosUI.babanoTotal = BabanosUI.babanoTotal + BabanosUI.babanoCounter;

            Debug.Log("Total " + BabanosUI.babanoTotal);
            Debug.Log("Counter " + BabanosUI.babanoCounter);
            Debug.Log("Goal " + BabanosUI.babanoGoal);

            if(BabanosUI.babanoTotal >= BabanosUI.babanoGoal){
                textScript.nextSceneToLoad = "WinScene";
            }
            textBoxBeforeChangingScene.SetActive(true);
            textScript.enabled = true;
        }
    }   
}