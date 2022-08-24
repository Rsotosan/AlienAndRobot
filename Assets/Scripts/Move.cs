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

        Debug.Log("Velocidad: " + agent.velocity);
        if (Input.GetMouseButtonDown(0)){
            RaycastHit hit;
                
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100)) {
                agent.destination = hit.point;
                Debug.Log(agent.destination);
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

            Debug.Log("isMovingFalse");

        }
        else
        {
            animator.SetBool("isMoving", true);
            Debug.Log("isMovingTrue");
        }

    }
}
