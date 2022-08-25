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

    //botonalien
    //
    
    private int counter = 0;


    private bool state = false;
    // Start is called before the first frame update
    void Start()
    {
 
        robotDialogue.text = "Haz click en cualquier lugar de la pantalla para iniciar el diálogo";
        alienDialogue.text = "";
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
                //if counter es impar

                string clave = texts[counter].Split(";")[0];

                string texto = texts[counter].Split(";")[1];

                //counter par

                robotDialogue.text = texts[counter - 1];
                alienDialogue.text = texts[counter];
                state = false;
            }
            else
            {
                Debug.Log("Se acabaron las líneas de díalogo");
                state = false;
            }
          

        }


    }


}
