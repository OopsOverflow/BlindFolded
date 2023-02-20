using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace Utils
{
    public class SwitchAttachPoint : MonoBehaviour
    {
        public XRGrabInteractable interactable;
        public GameObject rightController;
        public GameObject leftController;
        public GameObject originalAttachPoint;
        public GameObject alternativeAttachPoint;


        private void Update()
        {
            if (interactable.interactorsSelecting.Count <= 0) return;
            if (interactable.interactorsSelecting[0].transform.name == rightController.name)
            {
                interactable.attachTransform = originalAttachPoint.transform;
            }

            if (interactable.interactorsSelecting[0].transform.name == leftController.name)
            {
                interactable.attachTransform = alternativeAttachPoint.transform;
            }
        }
    }
}
