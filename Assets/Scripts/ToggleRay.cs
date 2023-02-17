using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleRay : MonoBehaviour
{
    public InputActionProperty gripAction;
    public GameObject xrComponent;
    private XRRayInteractor _rayInteractor;
    private XRInteractorLineVisual _lineVisual;

    private void OnEnable()
    {
        _rayInteractor = xrComponent.GetComponent<XRRayInteractor>();
        _lineVisual = xrComponent.GetComponent<XRInteractorLineVisual>();
    }

    private void Update()
    {
        if (gripAction.action.ReadValue<float>() > 0.9)
        {
            _rayInteractor.enabled = true;
            _lineVisual.enabled = true;
        }
        else
        {
            _rayInteractor.enabled = false;
            _lineVisual.enabled = false;        }
    }
}
