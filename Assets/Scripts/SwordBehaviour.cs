using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(7))
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    private void OnTriggerStay(Collider other)
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
}
