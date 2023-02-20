using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlimeBehaviour : MonoBehaviour
{
    [SerializeField] public int maxLifePoints;
    [SerializeField] public Transform chaseTarget; // The target to be chased
    [SerializeField] public float maxVisibility; // The object max "visibility" distance
    [SerializeField] public float minVisibility; // The object min "visibility" distance (used to stop the walking animation)
    [SerializeField] public NavMeshAgent agent; // The NavMeshAgent component assigned to this GameObject
    private Animator animator;
    private int currentLifePoints;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentLifePoints = maxLifePoints;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        // Get the distance between the player and enemy (this object)
        float distance = Vector3.Distance(chaseTarget.position, transform.position);

        // Check if it is within the range
        if(distance <= maxVisibility && distance >= minVisibility)
        {
            animator.SetBool("isMoving", true);  
            agent.SetDestination(chaseTarget.transform.position);
        } else {
            animator.SetBool("isMoving", false);
        }
    }

    public void TakeDamage(int dmg)
    {
        currentLifePoints -= dmg;
        if (currentLifePoints <= 0) {
            dead = true;
            gameObject.SetActive(false);
        }
    }

    public bool isDead() {
        return dead;
    }
}
