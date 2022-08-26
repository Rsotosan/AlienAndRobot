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
        } else {
            treeChop = null;
        }

        if(Physics.Raycast(theRay, out RaycastHit hit, 1)){
            if(hit.transform == treeChop){
                TreeComponents components = treeChop.GetComponent<TreeComponents>();

                foreach (GameObject banana in components.getBananas()) {
                    Rigidbody bananaRB = banana.GetComponent<Rigidbody>();
                    if(bananaRB.useGravity == false){
                        Debug.Log("Impulso bananil");
                        bananaRB.useGravity = true;
                        float xforce = Random.Range(-0.8f, 0.8f);
                        bananaRB.AddForce(xforce, 20f, 0);
                    }
                }
            }
        }
        

    }  


    void generateBananas(){

        foreach(GameObject tree in GameObject.FindGameObjectsWithTag("Tree")){
            List<int[]> positions = getPositionsRandom(Random.Range(0, 8));

            foreach(int[] pos in positions)
            {
                Transform sphera = GameObject.Instantiate(pointPrefab);
                TreeComponents components = tree.GetComponent<TreeComponents>();


                

                Vector3 position = new Vector3(tree.transform.position.x + pos[0] , tree.GetComponent<MeshFilter>().mesh.bounds.extents.y * tree.transform.localScale.y + tree.transform.position.y  , tree.transform.position.z + pos[1]);

                sphera.position = position;
                
                components.addBanana(sphera.gameObject); 
            }
            
        }

        
    }

    List<int[]> getPositionsRandom(int num){
        List<int[]> positions = getPositions();
        int size = positions.Count;
        for (int i = 0; i < size - num; i++)
        {
            positions.RemoveAt(Random.Range(0, positions.Count));
        }
        return positions;
    }
    List<int[]> getPositions(){
        int distance = 1;
        List<int[]> positions = new List<int[]>();
        positions.Add(new int[]{distance, 0});
        positions.Add(new int[]{-distance, 0});
        positions.Add(new int[]{distance, distance});
        positions.Add(new int[]{0, distance});
        positions.Add(new int[]{-distance, -distance});
        positions.Add(new int[]{0, -distance});
        positions.Add(new int[]{distance, -distance});
        positions.Add(new int[]{-distance, distance});
        return positions;
    }

    
    
}
