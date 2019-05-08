using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvetory : MonoBehaviour
{
    [System.Serializable]
    public struct item {
        public item(string Name, int Amount, Sprite Image, bool Interactable, bool Food, int Foodvalue)
        {
            name = Name;
            amount = Amount;
            image = Image;
            interactable = Interactable;
            foodvalue = Foodvalue;
            food = Food;
        }

        public string name;
        public int amount;
        public bool interactable;
        public Sprite image;
        public bool food;
        public int foodvalue;
    }

    public UIInfo uIInfo;
    Dictionary<string, GameObject> ItemIcons = new Dictionary<string, GameObject>();
    public GameObject inventory;
    public GameObject inventoryGrid;
    public GameObject itemIcon;
    [Space]
    public item[] items;
    //PlayerStats playerStats;
    PlayerActions playerActions;


    private void Start()
    {
        //playerStats = GetComponent<PlayerStats>();
        playerActions = GetComponent<PlayerActions>();
    }

    private void Update()
    {
    }

    public void Additem(string name, int amount)
    {
        for (int x = 0; x < items.Length; x++)
        {
            if (items[x].name == name)
            {
                items[x].amount += amount;
                uIInfo.AddTextItem("Added " + amount + " " + name + " to your inventory.");
                if (!ItemIcons.ContainsKey(name))
                {
                    GameObject justAdded = Instantiate(itemIcon, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), inventoryGrid.transform);
                    ItemIcons.Add(name, justAdded);
                    uIInfo.CreateItemIcon(ItemIcons[name], items[x].image, items[x].interactable);
                    uIInfo.UpdateItemIcon(ItemIcons[name], items[x].amount.ToString());
                }
                else
                {
                    uIInfo.UpdateItemIcon(ItemIcons[name], items[x].amount.ToString());
                }
                break;
            }
        }
    }

    public void Removeitem(string name, int amount)
    {
        for (int x = 0; x < items.Length; x++)
        {
            if (items[x].name == name)
            {
                items[x].amount -= amount;
                uIInfo.AddTextItem("Removed " + amount + " " + name + " from your inventory.");
                if (items[x].amount <= 0)
                {
                    Destroy(ItemIcons[name]);
                    ItemIcons.Remove(name);
                }
                else
                {
                    uIInfo.UpdateItemIcon(ItemIcons[name], items[x].amount.ToString());
                }
                break;
            }
        }
    }

    public void Interaction(GameObject itemIcon)
    {
        string itemname = "none";
        bool found = false;
        foreach (var item in ItemIcons)
        {
            if(item.Value == itemIcon)
            {
                itemname = item.Key;
                found = true;
                break;
            }
        }
        if (found)
        {
            for (int x = 0; x < items.Length; x++)
            {
                if (items[x].name == itemname)
                {
                    if (items[x].food)
                    {
                        //playerStats.UpdateFood(items[x].foodvalue);
                        Removeitem(items[x].name,1);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            found = false;
        }
    }
}
