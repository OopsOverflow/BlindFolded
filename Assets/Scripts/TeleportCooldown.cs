using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportCooldown : MonoBehaviour
{
    public GameObject leftControllerRayInteractor;
    
    public GameObject rightControllerRayInteractor;

    public GameObject leftLoading;
    public GameObject rightLoading;
    
    public Image leftCircle;
    public Image rightCircle;

    public bool isInCooldown = false;

    private float _cooldownValue = 5.0f;
    
    private float _startTime;

    public void ToggleTeleport()
    {
        leftControllerRayInteractor.SetActive(isInCooldown);
        rightControllerRayInteractor.SetActive(isInCooldown);
        leftLoading.SetActive(!isInCooldown);
        rightLoading.SetActive(!isInCooldown);
        leftCircle.fillAmount = 0;
        rightCircle.fillAmount = 0;
        isInCooldown = !isInCooldown;
        _startTime = Time.time;
    }

    private void Update()
    {
        if (!isInCooldown) return;
        if (Time.time >= _startTime + _cooldownValue)
        {
            ToggleTeleport();
        }
        else
        {
            leftCircle.fillAmount = (Time.time - _startTime) / _cooldownValue;
            rightCircle.fillAmount = (Time.time - _startTime) / _cooldownValue;
        }

    }
}
