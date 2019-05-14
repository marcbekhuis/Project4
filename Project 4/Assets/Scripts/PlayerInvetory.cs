using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInvetory : MonoBehaviour
{
    [System.Serializable]
    public struct item {
        public item(string Name, int Amount, Sprite Image, bool Interactable, bool Food, int Foodvalue, bool BuildBlock, TileBase[] Tiles)
        {
            name = Name;
            amount = Amount;
            image = Image;
            interactable = Interactable;
            foodvalue = Foodvalue;
            food = Food;
            buildBlock = BuildBlock;
            tiles = Tiles;
        }

        public string name;
        public int amount;
        public bool interactable;
        public Sprite image;
        public bool food;
        public int foodvalue;
        public bool buildBlock;
        public TileBase[] tiles;
    }

    [System.Serializable]
    public struct craftingItem
    {
        public craftingItem(string Name, string[] NeedItemName, int[] NeedItemAmount, Sprite Image)
        {
            name = Name;
            needItemName = NeedItemName;
            needItemAmount = NeedItemAmount;
            image = Image;
        }

        public string name;
        public string[] needItemName;
        public int[] needItemAmount;
        public Sprite image;
    }

    public UIInfo uIInfo;
    Dictionary<string, GameObject> itemIcons = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> craftingItemIcons = new Dictionary<string, GameObject>();
    public GameObject inventory;
    public GameObject inventoryGrid;
    public GameObject craftingInventoryGrid;
    public GameObject itemIcon;
    public GameObject craftingItemIcon;
    public item selectedItem;

    [Space]
    public item[] items;

    [Space]
    public craftingItem[] craftingItems;

    PlayerActions playerActions;


    private void Start()
    {
        playerActions = GetComponent<PlayerActions>();
        LoadCraftingItems();
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
                if (!itemIcons.ContainsKey(name))
                {
                    GameObject justAdded = Instantiate(itemIcon, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), inventoryGrid.transform);
                    itemIcons.Add(name, justAdded);
                    uIInfo.CreateItemIcon(itemIcons[name], items[x].image, items[x].interactable);
                    uIInfo.UpdateItemIcon(itemIcons[name], items[x].amount.ToString());
                }
                else
                {
                    uIInfo.UpdateItemIcon(itemIcons[name], items[x].amount.ToString());
                }
                if (selectedItem.name == items[x].name)
                {
                    selectedItem = items[x];
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
                    Destroy(itemIcons[name]);
                    itemIcons.Remove(name);
                }
                else
                {
                    uIInfo.UpdateItemIcon(itemIcons[name], items[x].amount.ToString());
                }
                if (selectedItem.name == items[x].name)
                {
                    selectedItem = items[x];
                }
                break;
            }
        }
    }

    public void InteractionInventory(GameObject itemIcon)
    {
        string itemname = "none";
        bool found = false;
        foreach (var item in itemIcons)
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
                        Removeitem(items[x].name,1);
                    }
                    else if (items[x].buildBlock)
                    {
                        selectedItem = items[x];
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

    public void LoadCraftingItems()
    {
        for (int x = 0; x < craftingItems.Length; x++)
        {
            GameObject justAdded = Instantiate(craftingItemIcon, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), craftingInventoryGrid.transform);
            craftingItemIcons.Add(craftingItems[x].name, justAdded);
            uIInfo.CreateItemIcon(craftingItemIcons[craftingItems[x].name], craftingItems[x].image, true);
        }
    }

    public void InteractionCrafting(GameObject itemIcon)
    {
        string itemname = "none";
        bool found = false;
        foreach (var item in craftingItemIcons)
        {
            if (item.Value == itemIcon)
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
                if (craftingItems[x].name == itemname)
                {
                    string text = "";
                    for (int t = 0; t < craftingItems[x].needItemName.Length; t++)
                    {
                        text += craftingItems[x].needItemName[t] + ": " + craftingItems[x].needItemAmount[t];
                    }
                    uIInfo.ShowCraftingInfo(craftingItems[x].image, text);
                }
            }
            found = false;
        }
    }
}
