using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftController : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] LineRenderer lineRenderer2;
    Ray ray;
    RaycastHit hit;
    int counter;

    // Start is called before the first frame update
    void Start()
    {
        ray = new Ray(transform.position, transform.forward);
        lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (counter > 60)
        {
            if (GetComponent<Renderer>().material.color != Color.blue) {
                GetComponent<Renderer>().material.color = Color.blue;
            } else {
                GetComponent<Renderer>().material.color = Color.white;
            }
            counter = 0;
        }
        counter++;

        if (Physics.Raycast(ray, out hit, 5))
        {
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, hit.point);
        } else
        {
            GetComponent<Renderer>().material.color = Color.green;
        }

        lineRenderer.SetVertexCount(2);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.forward * 20 + transform.position);
    }
}
