using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [SerializeField] public int maxLifePoints;

    private int currentLifePoints;

    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tookDamage(int dmg)
    {
        currentLifePoints -= dmg;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
        Debug.Log("Player was hit");
        
    }
}
