using System;
using UnityEngine;

public class Interactable : MonoBehaviour{
    private void OnCollisionEnter(Collision collision)
    {
        SoundWaveEffect.instance.StartScan(transform.position);
    }
}