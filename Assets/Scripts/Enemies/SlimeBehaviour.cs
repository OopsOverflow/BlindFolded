using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AudioRelated;

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
    private AudioSource hitAudio;
    private bool _isCooldownFinished = true;
    private float _cooldown = 3f;
    private float _soundCooldown = 0.5f;
    private bool _isInCooldown = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        currentLifePoints = maxLifePoints;
        dead = false;
        hitAudio = GetComponent<AudioSource>();
    }
    
    private IEnumerator CooldownStepCoRoutine(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        _isCooldownFinished = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(!_isCooldownFinished) return;
            SoundWaveEffect.instance.StartScan(gameObject.transform.position, 1f);
            _isCooldownFinished = false;
            StartCoroutine(CooldownStepCoRoutine(_cooldown));
    }

    private void FixedUpdate()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        // Get the distance between the player and enemy (this object)
        var distance = Vector3.Distance(chaseTarget.position, transform.position);

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
        if(_isInCooldown) return;
        SwordEffect.instance.SpawnSound(gameObject.transform.position);
        _isInCooldown = true;
        StartCoroutine(CooldownSwordCoRoutine(_soundCooldown));
        currentLifePoints -= dmg;

        hitAudio.Play();

        if (currentLifePoints <= 0) {
            dead = true;
            gameObject.SetActive(false);
        }
        
    }

    public bool IsDead() {
        return dead;
    }
    
    private IEnumerator CooldownSwordCoRoutine(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        _isInCooldown = false;
    }
    
}
