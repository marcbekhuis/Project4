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
        //puts the health to their max
        heartMode = 3;
        playerHealth = 3;
        fullPlayerHealth = 3;
        actualPlayerHealth = 6;
        fullActualPlayerHealth = 6;
    }

    // Update is called once per frame
    void Update()
    {
        //if AI health goes under is or goes lower than 0 it gets destroyed
        if (actualPlayerHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //checks if a collider with the tag "Deadly" hits the AI
        if (collision.gameObject.CompareTag("Deadly"))
        {
            //Removes health from the AI
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
    }
}
