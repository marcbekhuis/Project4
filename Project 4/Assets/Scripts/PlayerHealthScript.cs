using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealthScript : MonoBehaviour
{
    public GameObject heartPrefab;
    public List<Image> hearts = new List<Image>();
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;
    public GameObject healtchContainer;

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

        if (collision.gameObject.CompareTag("HealthUp"))
        {
            if (playerHealth <= 19)
            {
                GameObject justAdded = Instantiate(heartPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), healtchContainer.transform);
                hearts.Add(justAdded.GetComponent<Image>());
                fullActualPlayerHealth += 3;
                fullPlayerHealth += 1;
                actualPlayerHealth = fullActualPlayerHealth;
                playerHealth = fullPlayerHealth;
                heartMode = 3;
                healthLost = 0;
                for (int i = 0; i < hearts.Count; i++)
                {
                    hearts[i].sprite = fullHeart;
                }
            }else
            {
                actualPlayerHealth = fullActualPlayerHealth;
                playerHealth = fullPlayerHealth;
                heartMode = 3;
                healthLost = 0;
                for (int i = 0; i < hearts.Count; i++)
                {
                    hearts[i].sprite = fullHeart;
                }
            }
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
