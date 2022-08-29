using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BananaMovement : MonoBehaviour
{
    

    bool firstTimeTouching = true;
    Rigidbody rb;

    float timer;
    float nextChange;

    float lifeSpanTimer;

    float lifeSpan;

    private static int babanoCounter = 0;

    public enum BananaState {greenBanana,yellowBanana,redBanana };
    [SerializeField, Range(1, 10)]
    int minForce;
    [SerializeField, Range(1, 10)]
    int maxForce;
    [SerializeField]
    Material greenMaterial;
    [SerializeField]
    Material yellowMaterial;
    [SerializeField]
    Material redMaterial;

   public BananaState bananaState;

    [SerializeField]
    TextMeshProUGUI babanoUi;


    // Start is called before the first frame update


    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //generate a random float 1 time to determine how much the banana will live
        lifeSpan = Random.Range(1f, 14f);

        if (lifeSpan >= 1 && lifeSpan < 3)
        {
            GetComponent<MeshRenderer>().material = redMaterial;
            bananaState =  BananaState.redBanana;
        }

        if (lifeSpan >= 3 && lifeSpan < 8)
        {
            GetComponent<MeshRenderer>().material = yellowMaterial;
            bananaState = BananaState.yellowBanana;
        }
        if (lifeSpan >= 8 && lifeSpan <= 14)
        {
            GetComponent<MeshRenderer>().material = greenMaterial;
            bananaState = BananaState.greenBanana;
        }


    }

    // Update is called once per frame
    void Update()
    {

        if (firstTimeTouching == false)
        {

            timer += Time.deltaTime;
            lifeSpanTimer += Time.deltaTime;
            if (timer >= nextChange) {
                nextChange = Random.Range(1f, 3f);

                switch (bananaState)
                {
                    case BananaState.redBanana:
                        rb.velocity = new Vector3(randomForce(minForce, maxForce) *2, Random.Range(1, 4)*3, randomForce(minForce, maxForce) *2);

                        rb.AddForce(new Vector3(randomForce(minForce, maxForce) * 25, Random.Range(1, 4), randomForce(minForce, maxForce) * 25), ForceMode.Acceleration);

                        timer = 0f;
                        break;
                    case BananaState.greenBanana:
                        rb.velocity = new Vector3(randomForce(minForce, maxForce) * 0.75f, Random.Range(1, 4) * 1, randomForce(minForce, maxForce) * 0.75f);

                        rb.AddForce(new Vector3(randomForce(minForce, maxForce) * 25, Random.Range(1, 4), randomForce(minForce, maxForce) * 25), ForceMode.Acceleration);

                        timer = 0f;
                        break;

                    default:
                       
                        rb.velocity = new Vector3(randomForce(minForce, maxForce), Random.Range(1, 4), randomForce(minForce, maxForce));

                        rb.AddForce(new Vector3(randomForce(minForce, maxForce) * 25, Random.Range(1, 4), randomForce(minForce, maxForce) * 25), ForceMode.Acceleration);

                        timer = 0f;
                   
                        return;



                }
            
            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.tag == "Terrain" && firstTimeTouching)
        {
            rb.velocity = Vector3.zero;
           rb.velocity = new Vector3(randomForce(minForce, maxForce), Random.Range(1, 4), randomForce(minForce, maxForce));


            firstTimeTouching = false;
            nextChange = Random.Range(1f, 3f);
        }

        if(collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
            babanoCounter++;
            babanoUi.text = "X " + babanoCounter;
        }
    }



    private float randomForce(int minForce, int maxForce)
    {
        float random = Random.Range(minForce, maxForce);

        if(Random.Range(0,3) > 1)
        {
            return random;
        }
       
        return -random;
    }

}
