using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class FireCooldown : MonoBehaviour
{
    public TeleportationProvider provider;

    public GameObject teleportController;

    private TeleportCooldown _utilityFunction;


    private void Start()
    {
        _utilityFunction = teleportController.GetComponent<TeleportCooldown>();
        provider.endLocomotion += (x) =>
        {
            _utilityFunction.ToggleTeleport();
            SoundWaveEffect.instance.StartScan(x.transform.position, 2);
        };
    }

    
}
