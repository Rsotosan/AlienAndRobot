using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BabanosUI : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI babanoUi;

    public static int babanoCounter = 0;
    public static int babanoGoal = 80;

    public static int babanoTotal = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Banana")
        {

            if(collision.gameObject.GetComponent<BananaMovement>().bananaState == BananaMovement.BananaState.redBanana)
                {
                babanoCounter = babanoCounter + 5;
                babanoUi.text = "X " + babanoCounter;
                return;
                }
            if (collision.gameObject.GetComponent<BananaMovement>().bananaState == BananaMovement.BananaState.yellowBanana)
            {
                babanoCounter = babanoCounter + 3;
                babanoUi.text = "X " + babanoCounter;
                return;
            }
            else
            {
                babanoCounter++;
                babanoUi.text = "X " + babanoCounter;
            }
           
        }
    }
}
