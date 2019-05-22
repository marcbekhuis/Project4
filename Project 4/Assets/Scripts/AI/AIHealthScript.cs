using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AIHealthScript : MonoBehaviour
{
    private int playerHealth;
    private int fullPlayerHealth;
    private int healthLost;
    private int actualPlayerHealth;
    private int fullActualPlayerHealth;
    private int heartMode;

    // Start is called before the first frame update
    void Start()
    {
        heartMode = 3;
        playerHealth = 3;
        fullPlayerHealth = 3;
        actualPlayerHealth = 6;
        fullActualPlayerHealth = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualPlayerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly"))
        {
            actualPlayerHealth--;
            healthLost++;
            heartMode--;
            if (healthLost >= 3)
            {
                playerHealth--;
                healthLost = 0;
                heartMode = 2;
            }
        }

        else if (collision.gameObject.CompareTag("HealthUp"))
        {
            if (playerHealth <= 19)
            {
                fullActualPlayerHealth += 3;
                fullPlayerHealth += 1;
                actualPlayerHealth = fullActualPlayerHealth;
                playerHealth = fullPlayerHealth;
                heartMode = 3;
                healthLost = 0;
            }else
            {
                actualPlayerHealth = fullActualPlayerHealth;
                playerHealth = fullPlayerHealth;
                heartMode = 3;
                healthLost = 0;
            }
            collision.gameObject.SetActive(false);
        }

        else if (collision.gameObject.CompareTag("HealthRestore"))
        {
            if (playerHealth != fullPlayerHealth)
            {
                playerHealth += 2;

                if (playerHealth > fullPlayerHealth)
                {
                    playerHealth = fullPlayerHealth;
                }
            }
        }
    }
}
