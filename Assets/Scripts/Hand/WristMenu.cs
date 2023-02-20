using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
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
        if (wristUICanvas.activeSelf)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void ResumeGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        wristUICanvas.SetActive(false);
    }
}
