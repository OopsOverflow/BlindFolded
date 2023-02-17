using System.Collections;
using UnityEngine;

public class PlayAudioWhenMoving : MonoBehaviour
{
    private AudioSource _audioSource;
    private Rigidbody _rigidbody;
    private bool _isCooldownFinished = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude > 4 && _rigidbody.isKinematic)
        {
            if (!_audioSource.isPlaying && _isCooldownFinished)
            {
                _audioSource.Play();
                _isCooldownFinished = false;
                StartCoroutine(CooldownSwingCoRoutine(0.1f));
            }
        }
        else
        {
            if (_audioSource.isPlaying && !_rigidbody.isKinematic)
            {
                _audioSource.Stop();
            }
        }
    }

    private IEnumerator CooldownSwingCoRoutine(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        _isCooldownFinished = true;
    }
}