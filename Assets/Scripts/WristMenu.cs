using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class WristMenu : MonoBehaviour
{
    public InputActionProperty menu;
    public GameObject wristUICanvas;

    private void Start()
    {
        wristUICanvas.SetActive(false);
        menu.action.started += ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext callbackContext)
    {
        wristUICanvas.SetActive(!wristUICanvas.activeSelf);
    }

    public void ResumeGame()
    {
        wristUICanvas.SetActive(false);
    }
}
