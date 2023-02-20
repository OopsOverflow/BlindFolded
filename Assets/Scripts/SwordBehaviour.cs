using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    private Renderer renderer;
    private Outline outline;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(7)) // Layer 7 is for 'hittable' objects
        {
            renderer.material.color = Color.red;
            outline.OutlineColor = Color.red;
            SlimeBehaviour slimeBehaviour = other.GetComponent<SlimeBehaviour>();
            if (slimeBehaviour != null)
            {
                slimeBehaviour.TakeDamage(50);

                // Reset sword's color to normal when enemy dies
                if(slimeBehaviour.isDead()) {
                    renderer.material.color = Color.white;
                    outline.OutlineColor = Color.white;

                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        renderer.material.color = Color.white;
        outline.OutlineColor = Color.white;
    }

    private void OnTriggerStay(Collider other)
    {
        //GetComponent<Renderer>().material.color = Color.white;
    }
}
