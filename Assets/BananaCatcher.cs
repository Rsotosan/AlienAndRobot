using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaCatcher : MonoBehaviour
{

    private Transform alien;
    // Start is called before the first frame update
    void Start()
    {
        alien = this.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray theRay = new Ray(alien.position, alien.TransformDirection(Vector3.forward * 1));
        Debug.DrawRay(alien.position, alien.TransformDirection(Vector3.forward * 1));

        if (Physics.Raycast(theRay, out RaycastHit hit, 1))
        {
            if (hit.transform.tag == "Banana")
            {
                Debug.Log("COGISTE BANANA");

                Destroy(hit.transform.gameObject);
            }
        }


    }
}
