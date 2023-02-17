using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAudioBehaviour : MonoBehaviour
{
    private AudioSource audioSource;
    private Animator animator;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (animator.GetBool("isMoving"))
        {
            Debug.Log("playing music");
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
