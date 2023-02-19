using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwordAttachPoint : MonoBehaviour
{
    public XRGrabInteractable interactable;
    public GameObject rightController;
    public GameObject leftController;
    public GameObject originalAttachPoint;
    public GameObject alternativeAttachPoint;



    void Update()
    {
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
