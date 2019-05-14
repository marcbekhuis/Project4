using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public Image[] hearts = new Image[3];
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    private int playerHealth;
    private int healthLost;
    private int actualPlayerHealth;
    private int heartMode;

    // Start is called before the first frame update
    void Start()
    {
        heartMode = 3;
        playerHealth = 3;
        actualPlayerHealth = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualPlayerHealth <= 0)
        {
            SceneManager.LoadScene(2);
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
            Changeheart();
        }
    }

    private void Changeheart()
    {
        if (heartMode == 1)
        {
            hearts[playerHealth - 1].sprite = emptyHeart;
        }
        else if (heartMode == 2)
        {
            hearts[playerHealth - 1].sprite = halfHeart;
        }
        else if (heartMode == 3)
        {
            hearts[playerHealth - 1].sprite = fullHeart;
        }
    }
}
