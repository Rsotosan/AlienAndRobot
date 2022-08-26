using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Move : MonoBehaviour
{
    Vector3 pos;

    NavMeshAgent agent;
    Rigidbody rb;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
                
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.isStopped = false;
                if(hit.transform.tag == "Tree"){
                    NavMeshHit myNavHit;
                    if(NavMesh.SamplePosition(hit.transform.position, out myNavHit, 100 , -1))
                    {
                        agent.destination = myNavHit.position;
                    }
                }
                else {
                    agent.destination = hit.point;
                }
            }

            if(agent.remainingDistance < agent.stoppingDistance) 
            {
             agent.updateRotation = false;
            Debug.Log("Rotando hacia arbol");
             GameObject.Find("Alien").transform.rotation = Quaternion.LookRotation(agent.destination);
            }
            else {
                agent.updateRotation = true;
            }


        }

        //player.MovePosition(agent.destination);

        animationController();   

    }



    void animationController()
    {
        if (agent.velocity == Vector3.zero)
        {
            animator.SetBool("isMoving", false);
        }
        else
        {
            animator.SetBool("isMoving", true);
        }

    }

    private void OnCollisionEnter(Collision other) {
        agent.isStopped = true;
    }
}
