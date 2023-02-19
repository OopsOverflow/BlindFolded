using System.Collections;
using AudioRelated;
using UnityEngine;

public class PlayAudioWhenMoving : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _cooldown = 0.5f;
    private bool _isInCooldown = false;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody.velocity.magnitude > 4 && _rigidbody.isKinematic)
        {
           if(_isInCooldown) return;
           SwordEffect.instance.SpawnSound(gameObject.transform.position);
           _isInCooldown = true;
            StartCoroutine(CooldownSwordCoRoutine(_cooldown));
        }
    }
    
    private IEnumerator CooldownSwordCoRoutine(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        _isInCooldown = false;
    }
}