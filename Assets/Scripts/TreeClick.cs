using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TreeClick : MonoBehaviour
{
    [SerializeField]
    Transform pointPrefab;


    private Transform alien;

    private Transform treeChop;
    // Start is called before the first frame update

    private bool isCuttingTree = false;
    private int counter;
    
    private static int CUT_NUMBER = 4;
    Animator animator;

    void Start()
    {
        name = this.GetComponent<Transform>().name;
        alien = GameObject.Find("Alien").transform;
        animator = alien.GetComponent<Animator>();

        generateBananas();

    }
    void Update(){
        if(!isCuttingTree){

            moveToTree();

        } else{

            cutTree();

        }
    }  

    void startCutTree(){

        alien.GetComponent<NavMeshAgent>().enabled = false;
        
        isCuttingTree = true;

    }

    void stopCutTree(){
        bananaJump();

        alien.GetComponent<NavMeshAgent>().enabled = true;
        
        isCuttingTree = false;

        counter = 0;

        treeChop = null;

        animator.SetBool("isCutting", false);

        
    }

    void bananaJump(){

        TreeComponents components = treeChop.GetComponent<TreeComponents>();

        foreach (GameObject banana in components.getBananas()) {
            Rigidbody bananaRB = banana.GetComponent<Rigidbody>();
            if(bananaRB.useGravity == false){
                bananaRB.useGravity = true;
                float xforce = Random.Range(-0.8f, 0.8f);
                bananaRB.AddForce(xforce, 20f, 0);
            }
        }

        components.clear();
    }

    

    void moveToTree(){
        Ray theRay = new Ray(alien.position, alien.TransformDirection(Vector3.forward * 1));
        Debug.DrawRay(alien.position, alien.TransformDirection(Vector3.forward * 1));
        if (Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitMouse)){
                if (hitMouse.transform.tag == "Tree"){

                    GameObject tree = hitMouse.transform.gameObject;
                    if(tree.GetComponent<TreeComponents>().haveBananas()) treeChop = tree.transform;

                } else {
                    treeChop = null;
                }
            }
        }

        if(Physics.Raycast(theRay, out RaycastHit hit, 1)){
            if(hit.transform == treeChop){
                startCutTree();
            }
        }
    }

        
        
    void cutTree(){
        if(counter < CUT_NUMBER){
            if (Input.GetMouseButtonDown(0)){
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hitMouse)){
                    if (hitMouse.transform == treeChop){      
                        cutAction();
                    }
                }
            }

            if (animator.GetBool("isCutting") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1)
            {
                animator.SetBool("isCutting", false);
            }
        } else {
            stopCutTree();
        }
    }
    
    void cutAction(){
        if(!animator.GetBool("isCutting")){
            animator.SetBool("isCutting", true);
            counter++;
        }
        if (animator.GetBool("isCutting") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5)
        {
            animator.Play("AlienArmature|Alien_SwordSlash 0", -1, 0.0f);
            counter++;
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
