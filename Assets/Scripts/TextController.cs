    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TextController : MonoBehaviour
{
    [SerializeField]
    List<string> texts;
    [SerializeField]
    TextMeshProUGUI robotDialogue;
    [SerializeField]
    TextMeshProUGUI alienDialogue;
    [SerializeField]
    GameObject robotButton;
    [SerializeField]
    GameObject alienButton;
    [SerializeField]
    string firstText;
    [SerializeField]
    public string nextSceneToLoad;

    [SerializeField]
    AudioSource alienVoice;

    [SerializeField]
    AudioSource robotVoice;
    

    //botonalien
    //

    private int counter = 0;


    private bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        if(robotVoice != null) robotVoice.Play();
        robotDialogue.text = firstText;
        alienDialogue.text = "";
        alienButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("MOUSE PULSADO");
            counter++;
            state = true;
        }
        if (state)
        {
            Debug.Log(counter + " " + texts.Count);
            if (counter <= texts.Count)
            {
                string[]dividedText = texts[counter].Split(";",2);
                string key = dividedText[0];
                string text = dividedText[1];
                if (key.Equals("1"))
                    {
                        if(robotVoice != null) robotVoice.Play();
                        alienButton.SetActive(false);
                        robotButton.SetActive(true);
                        robotDialogue.text = text;
                        state = false;
                    }

                if (key.Equals("2"))
                    {
                        if(alienVoice != null) alienVoice.Play();
                        robotButton.SetActive(false);
                        alienButton.SetActive(true);
                        alienDialogue.text = text;
                        state = false;
                    }
                if (key.Equals("3"))
                    {
                        alienButton.SetActive(false);
                        robotButton.SetActive(true);
                        robotDialogue.text = "You brought me " + BabanosUI.babanoCounter +" babanos. I still have " +  (BabanosUI.babanoGoal - BabanosUI.babanoTotal) + " to go";
                        BabanosUI.babanoCounter = 0;
                        state = false;
                    }
                }
            else
            {
                SceneManager.LoadScene(nextSceneToLoad);
                Debug.Log("Se acabaron las l�neas de d�alogo");
                state = false;
            }

        }
            
          

        }


    }



