using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utils
{
    public class Tutorial : MonoBehaviour
    {
        public GameObject tutorialCanvas;

        public void RemoveTutorial()
        {
            tutorialCanvas.SetActive(false);
        }
    }
}