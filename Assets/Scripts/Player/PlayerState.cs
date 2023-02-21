using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerState : MonoBehaviour
{
    public int maxLifePoints;
    public TextMeshProUGUI lifePointsText;

    private int currentLifePoints;

    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
        lifePointsText.text = currentLifePoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int dmg)
    {
        currentLifePoints -= dmg;

        if(currentLifePoints <= 0) {
            SceneManager.LoadScene("Menu Scene");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(7)) // Layer 7 is for 'hittable' objects
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(-other.gameObject.transform.forward * 5, ForceMode.Impulse);
            TakeDamage(50);
            lifePointsText.text = currentLifePoints.ToString();
        }

        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Victory Scene");
        }
    }
}
