using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class DeathMenu : MonoBehaviour
    {
        public GameObject deathCanvas;

        public void ShowDeathScreen()
        {
            Time.timeScale = 0;
            deathCanvas.SetActive(true);
        }

    }
}