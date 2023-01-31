using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeBehaviour : MonoBehaviour
{

    [SerializeField] public Transform chaseTarget; //drag and stop player object in the inspector
    [SerializeField] public float withinRange;
    [SerializeField] public float speed;
    Animator animator;

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Set the animator reference
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
        /*int seconds = 50;

        if (counter < 3 * seconds)
        {
            Vector3 vector3 = new Vector3(0, 0, 0.008f);
            transform.position += vector3;
        }

        if (counter == 3 * seconds)
        {
            animator.SetBool("isMoving", false);
        }

        counter ++;
        if (counter == 6 * seconds)
        {
            counter = 0;
            animator.SetBool("isMoving", true);
        }*/

        transform.LookAt(chaseTarget.position);

        // Get the distance between the player and enemy (this object)
        float distance = Vector3.Distance(chaseTarget.position, transform.position);

        // Check if it is within the range
        if(distance <= withinRange && distance >= 0.05)
        {
            animator.SetBool("isMoving", true);
            transform.position = Vector3.MoveTowards(transform.position, chaseTarget.transform.position, speed);    
        } else {
            animator.SetBool("isMoving", false);
        }
    }
}
