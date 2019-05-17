using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIInfo : MonoBehaviour
{
    public class Memory
    {
        public Memory(float Time, GameObject Text, int Code)
        {
            time = Time;
            text = Text;
            code = Code;
        }
        public float time;
        public GameObject text;
        public int code;
    }

    public GameObject textHolder;
    public GameObject textObject;
    Dictionary<Collider2D, GameObject> MemoryCollision = new Dictionary<Collider2D, GameObject>();
    List<Memory> MemoryItems = new List<Memory>();
    public Text healthText;
    public Text staminaText;
    public Text foodText;
    public PlayerInvetory playerInvetory;
    public PlayerActions playerActions;
    public float timeSec;
    public float timeMin;
    public Text timeText;
    public Image craftingImage;
    public Text craftingText;
    public Text craftingTitle;

    void start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        timeText.text = "Time survived: " + timeMin.ToString("F0") + ":" + timeSec.ToString("F0");
    }

    void Update()
    {
        if (!playerActions.gamePaused)
        {
            timeSec += Time.deltaTime;
            if (timeSec >= 60)
            {
                timeSec -= 60;
                timeMin++;
            }
        }
        timeText.text = "Time survived: " + timeMin.ToString("F0") + ":" + timeSec.ToString("F0");
    }

    private void FixedUpdate()
    {
        for (int x = 0; x < MemoryItems.Count; x++)
        {
            if (MemoryItems[x].time <= 0)
            {
                Destroy(MemoryItems[x].text);
                MemoryItems.RemoveAt(x);
            }
            else
            {
                MemoryItems[x].time -= Time.deltaTime;
            }
        }
    }

    public void AddTextCollision(string text, Collider2D collider)
    {
        GameObject justAdded = Instantiate(textObject, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), textHolder.transform);
        justAdded.GetComponent<Text>().text = text;
        MemoryCollision.Add(collider, justAdded);
    }

    public void RemoveTextCollision(Collider2D collider)
    {
        Destroy(MemoryCollision[collider]);
        MemoryCollision.Remove(collider);
    }

    public void AddTextItem(string text)
    {
        GameObject justAdded = Instantiate(textObject, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), textHolder.transform);
        justAdded.GetComponent<Text>().text = text;
        MemoryItems.Add(new Memory(1, justAdded, Random.Range(0, 100)));
    }

    public void UpdateHealthUI(int value)
    {
        healthText.text = "HP: " + value;
    }

    public void UpdateStaminaUI(int value)
    {
        staminaText.text = "Stamina: " + value;
    }

    public void UpdateFoodUI(int value)
    {
        foodText.text = "Food: " + value;
    }

    public void CreateItemIcon(GameObject itemIcon, Sprite sprite, bool interactable)
    {
        itemIcon.transform.Find("Image").GetComponentInChildren<Image>().sprite = sprite;
        Button justButton = itemIcon.GetComponent<Button>();
        justButton.interactable = interactable;
        justButton.onClick.AddListener(() => playerInvetory.InteractionInventory(itemIcon));
    }

    public void UpdateItemIcon(GameObject itemIcon, string value)
    {
        itemIcon.GetComponentInChildren<Text>(true).text = value;
    }

    public void ToggleMenu(GameObject menu)
    {
        if (menu.activeSelf)
        {
            menu.SetActive(false);
            //playerActions.allowAction = true;
        }
        else
        {
            menu.SetActive(true);
            //playerActions.allowAction = false;
        }
    }

    public void CreateCraftingItemIcon(GameObject itemIcon, Sprite sprite, bool interactable)
    {
        itemIcon.transform.Find("Image").GetComponentInChildren<Image>().sprite = sprite;
        Button justButton = itemIcon.GetComponent<Button>();
        justButton.interactable = interactable;
        justButton.onClick.AddListener(() => playerInvetory.InteractionCrafting(itemIcon));
    }

    public void ShowCraftingInfo(Sprite image, string neededItems, string name)
    {
        craftingImage.sprite = image;
        craftingText.text = neededItems;
        craftingTitle.text = name;
    }
}
