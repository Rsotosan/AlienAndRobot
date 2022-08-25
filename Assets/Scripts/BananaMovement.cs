using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaMovement : MonoBehaviour
{
    bool firstTimeTouching = true;
    Rigidbody rb;

    float timer;
    float nextChange;
    // Start is called before the first frame update

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (firstTimeTouching == false)
        {
            timer += Time.deltaTime;
           
            if(timer >= nextChange) {
                nextChange = Random.Range(1f, 3f);

                rb.velocity = new Vector3(randomForce(), Random.Range(1, 4), randomForce());
                
                timer = 0f;
            }


        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if(collision.transform.tag == "Terrain" && firstTimeTouching)
        {
            rb.velocity = Vector3.zero;

            rb.velocity = new Vector3(randomForce(), Random.Range(1, 4), randomForce());

            firstTimeTouching = false;
            nextChange = Random.Range(1f, 3f);
        }

        if(collision.transform.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }



    private float randomForce()
    {
        float random = Random.Range(5, 10);

        if(Random.Range(0,3) > 1)
        {
            return random;
        }
       
        return -random;
    }

}
