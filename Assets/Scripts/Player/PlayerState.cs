using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Utils;

public class PlayerState : MonoBehaviour
{
    public int maxLifePoints;
    public TextMeshProUGUI lifePointsText;
    public Image lifeBar;

    private int currentLifePoints;

    private float _attackCooldown = 1.5f;
    private bool _attackCooldownFinished = true;

    public Image redImage;
    

    // Start is called before the first frame update
    void Start()
    {
        currentLifePoints = maxLifePoints;
        lifePointsText.text = currentLifePoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (redImage.color.a > 0)
        {
            var color = redImage.color;
            color.a -= 0.01f;
            redImage.color = color;
        }
    }
    
    private IEnumerator CooldownStepCoRoutine(float cooldownTime)
    {
        yield return new WaitForSeconds(cooldownTime);
        _attackCooldownFinished = true;
    }

    public void TakeDamage(int dmg)
    {
        var color = redImage.color;
        color.a = 0.6f;
        redImage.color = color;
        currentLifePoints -= dmg;
        lifeBar.fillAmount = (float) currentLifePoints / maxLifePoints;

        if(currentLifePoints <= 0) {
            color.a = 0f;
            redImage.color = color;
            GetComponent<DeathMenu>().ShowDeathScreen();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(7)) // Layer 7 is for 'hittable' objects
        {
            if(!_attackCooldownFinished) return;
            //other.gameObject.GetComponent<Rigidbody>().AddForce(-other.gameObject.transform.forward * 5, ForceMode.Impulse);
            TakeDamage(25);
            lifePointsText.text = currentLifePoints.ToString();
            _attackCooldownFinished = false;
            StartCoroutine(CooldownStepCoRoutine(_attackCooldown));
        }

        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("Victory Scene");
        }
    }
}
