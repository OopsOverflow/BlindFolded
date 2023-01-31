using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBehaviour : MonoBehaviour
{

    [SerializeField] public Transform chaseTarget; // The target to be chased
    [SerializeField] public float withinRange; // The object max "visibility" distance
    [SerializeField] public float innerRange; // The object min "visibility" distance (used to stop the walking animation)
    [SerializeField] public NavMeshAgent agent; // The NavMeshAgent component assigned to this GameObject
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        chasePlayer();
    }

    void chasePlayer()
    {
        // Get the distance between the player and enemy (this object)
        float distance = Vector3.Distance(chaseTarget.position, transform.position);

        // Check if it is within the range
        if(distance <= withinRange && distance >= innerRange)
        {
            animator.SetBool("isMoving", true);  
            agent.SetDestination(chaseTarget.transform.position);
        } else {
            animator.SetBool("isMoving", false);
        }
    }
}
