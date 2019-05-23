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
    public SaveData saveData;
    public AudioSource playerSound;
    public AudioClip playerHit;

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
        //Checks if actualPlayerHealth is less or equal than 0
        if (actualPlayerHealth <= 0)
        {
            //Stores the time in saveData
            saveData.SaveDataTime();
            //Calls SceneManager and loads scene 2
            SceneManager.LoadScene(2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks for the tag deadly when colliding with another game object
        if (collision.gameObject.CompareTag("Deadly"))
        {
            //Changes several variables on collision with an object tagged as "Deadly"
            actualPlayerHealth--;
            healthLost++;
            heartMode--;
            if (healthLost >= 3)
            {
                playerHealth--;
                healthLost = 0;
                heartMode = 2;
            }
            //Plays a sound when player gets hit
            playerSound.clip = playerHit;
            playerSound.Play();
            //Calls the changeheart function to change the sprite depending on the current heartMode
            Changeheart();
        }
        //Checks for the tag HealthUp when colliding with another game object
        else if (collision.gameObject.CompareTag("HealthUp"))
        {
            if (playerHealth <= 19)
            {
                //When the playerHealth meets a certain threshold a heart sprite will be instantiated and sets variables to preset values
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
    //A function that changes the heart sprite when conditions are met
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
