using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    

    //botonalien
    //

    private int counter = 0;


    private bool state = false;
    // Start is called before the first frame update
    void Start()
    {
 
        robotDialogue.text = "Haz click en cualquier lugar de la pantalla para iniciar el diálogo";
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

            if (counter <= texts.Count)
            {
     

                string[]dividedText = texts[counter].Split(";",2);


                string key = dividedText[0];
                string text = dividedText[1];


                if (key.Equals("1"))
                {
                    alienButton.SetActive(false);
                    robotButton.SetActive(true);
                    robotDialogue.text = text;
                    state = false;
                }

                if (key.Equals("2"))
                {
                    robotButton.SetActive(false);
                    alienButton.SetActive(true);
                    alienDialogue.text = text;
                    state = false;
                }
                

                }
       
            }
            else
            {
                Debug.Log("Se acabaron las líneas de díalogo");
                state = false;
            }
          

        }


    }



