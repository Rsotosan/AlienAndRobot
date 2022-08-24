using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  


public class TreeClick : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;

    private string name;

    private Transform alien;

    private Transform treeChop;
    // Start is called before the first frame update
    void Start()
    {
        name = this.GetComponent<Transform>().name;
        alien = GameObject.Find("Alien").transform;

        generateBananas();

    }
    void Update(){
        Ray theRay = new Ray(alien.position, alien.TransformDirection(Vector3.forward * 1));
        Debug.DrawRay(alien.position, alien.TransformDirection(Vector3.forward * 1));

        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitMouse)){
                if (hitMouse.transform.tag == "Tree"){

                    GameObject tree = hitMouse.transform.gameObject;
                    treeChop = tree.transform;

                    Debug.Log("Estas pulsando el arbol " + tree.transform.name);

                }
            }
        }

        /**
        if(Physics.Raycast(theRay, out RaycastHit hit, 1)){
            if(hit.transform == treeChop){
                Debug.Log("ESTAS TALANDO EL JODIDO ARBOL");
                foreach (Transform banana in treeChop.transform.Find("bananas")){
                    banana.GetComponent<Rigidbody>().useGravity = true;
                }
            }

        }
        */

        if(Physics.Raycast(theRay, out RaycastHit hit, 1)){
            if(hit.transform == treeChop){
                TreeComponents components = treeChop.GetComponent<TreeComponents>();

                foreach (GameObject banana in components.getBananas()) {
                    Rigidbody bananaRB = banana.GetComponent<Rigidbody>();
                    bananaRB.useGravity = true;
                    float xforce = Random.Range(-0.8f, 0.8f);
                    bananaRB.AddForce(xforce, 2.8f, 0);
                }
            }
        }
        

    }  


    void generateBananas(){

        foreach(GameObject tree in GameObject.FindGameObjectsWithTag("Tree")){

            for (int i = 0; i < 5; i++)
            {
                Transform sphera = GameObject.Instantiate(pointPrefab);
                TreeComponents components = tree.GetComponent<TreeComponents>();
                components.addBanana(sphera.gameObject); 
            }
            
        }

        
    }
}
