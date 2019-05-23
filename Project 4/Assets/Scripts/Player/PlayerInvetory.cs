using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInvetory : MonoBehaviour
{
    // [System.Serializable] Allows you to edit the struct in the inspector
    [System.Serializable]
    // A struct that holds all the information that a item needs.
    public struct item {
        public item(string Name, int Amount, Sprite Image, bool Interactable, bool Food, int Foodvalue, bool BuildBlock, TileBase[] Tiles, bool IsSword, bool IsAxe, bool IsPickaxe)
        {
            name = Name;
            amount = Amount;
            image = Image;
            interactable = Interactable;
            foodvalue = Foodvalue;
            food = Food;
            buildBlock = BuildBlock;
            tiles = Tiles;
            isSword = IsSword;
            isAxe = IsAxe;
            isPickaxe = IsPickaxe;
        }

        public string name;
        public int amount;
        public bool interactable;
        public Sprite image;
        public bool food;
        public int foodvalue;
        public bool buildBlock;
        public TileBase[] tiles;
        public bool isSword;
        public bool isAxe;
        public bool isPickaxe;
    }

    // struct that holds all the information that a crafting item needs.
    [System.Serializable]
    public struct craftingItem
    {
        public craftingItem(string Name, string[] NeedItemName, int[] NeedItemAmount, Sprite Image, int AmountGetting)
        {
            name = Name;
            needItemName = NeedItemName;
            needItemAmount = NeedItemAmount;
            image = Image;
            amountGetting = AmountGetting;
        }

        public string name;
        public string[] needItemName;
        public int[] needItemAmount;
        public Sprite image;
        public int amountGetting;
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
    public GameObject selectedCraftingIcon;
    craftingItem selectedCraftingItem;

    // the array of items in the game
    [Space]
    public item[] items;

    // the array of crafting items in the game
    [Space]
    public craftingItem[] craftingItems;

    PlayerActions playerActions;


    private void Start()
    {
        // Gets the playerAction from the object this script is on.
        playerActions = GetComponent<PlayerActions>();
        // makes a button for every crafting item.
        LoadCraftingItems();
    }

    // Adds an item to your invetory
    public void Additem(string name, int amount)
    {
        // Loop to loop through all the items that there are.
        for (int x = 0; x < items.Length; x++)
        {
            // Checks if the item the loop is add has the same name as the one that should be added.
            if (items[x].name == name)
            {
                // adds the amount you want to add to the item.
                items[x].amount += amount;
                // call a function that show a item has been added to your inventory
                uIInfo.AddTextItem("Added " + amount + " " + name + " to your inventory.");
                // checks if the item has a itemicon in your inventory yet.
                if (!itemIcons.ContainsKey(name))
                {
                    // adds an icon to your inventory
                    GameObject justAdded = Instantiate(itemIcon, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), inventoryGrid.transform);
                    itemIcons.Add(name, justAdded);
                    uIInfo.CreateItemIcon(itemIcons[name], items[x].image, items[x].interactable);
                    uIInfo.UpdateItemIcon(itemIcons[name], items[x].amount.ToString());
                }
                // if there is it will update the icon to show the right amount
                else
                {
                    uIInfo.UpdateItemIcon(itemIcons[name], items[x].amount.ToString());
                }
                // if a item is selected it will update the item.
                if (selectedItem.name == items[x].name)
                {
                    selectedItem = items[x];
                }
                break;
            }
        }
    }

    // removes an item from your inventory
    public void Removeitem(string name, int amount)
    {
        // Loop to loop through all the items that there are.
        for (int x = 0; x < items.Length; x++)
        {
            // Checks if the item the loop is add has the same name as the one that should be added.
            if (items[x].name == name)
            {
                // removes the amount you want to add to the item.
                items[x].amount -= amount;
                // call a function that show a item has been removed from your inventory
                uIInfo.AddTextItem("Removed " + amount + " " + name + " from your inventory.");
                // checks if you dont have any of the item left in your inventory
                if (items[x].amount <= 0)
                {
                    // destroy the icon and removes it from the list.
                    Destroy(itemIcons[name]);
                    itemIcons.Remove(name);
                }
                // checks if you still have the item in your inventory. and updates the amount the icon shows.
                else
                {
                    uIInfo.UpdateItemIcon(itemIcons[name], items[x].amount.ToString());
                }
                // if a item is selected it will update the item.
                if (selectedItem.name == items[x].name)
                {
                    selectedItem = items[x];
                }
                break;
            }
        }
    }

    // Function that will be called when you click on a item that you can interact with
    public void InteractionInventory(GameObject itemIcon)
    {
        // sets the itemname to none
        string itemname = "none";
        bool found = false;
        // loops through all the item icons.
        foreach (var item in itemIcons)
        {
            // checks if object are the same
            if(item.Value == itemIcon)
            {
                // sets itemname to item.key name and set bool found to true
                itemname = item.Key;
                found = true;
                break;
            }
        }
        // checks if found is true
        if (found)
        {
            // loops through all the items.
            for (int x = 0; x < items.Length; x++)
            {
                // checks if item names are the same.
                if (items[x].name == itemname)
                {
                    // checks if bool buildblock is true in the item.
                    if (items[x].buildBlock)
                    {
                        // makes the item the selected item to build with.
                        selectedItem = items[x];
                        break;
                    }
                    // checks if bool isSword is true in the item.
                    else if (items[x].isSword)
                    {
                        // if bool is true it will make all bool false
                        if (playerActions.swordEquipped)
                        {
                            playerActions.swordEquipped = false;
                            playerActions.pickaxeEquipped = false;
                            playerActions.axeEquipped = false;
                            break;
                        }
                        // if bool is false it will make the bool true and others false
                        else
                        {
                            playerActions.swordEquipped = true;
                            playerActions.pickaxeEquipped = false;
                            playerActions.axeEquipped = false;
                            break;
                        }
                    }
                    // checks if bool isPickaxe is true in the item.
                    else if (items[x].isPickaxe)
                    {
                        // if bool is true it will make all bool false
                        if (playerActions.pickaxeEquipped)
                        {
                            playerActions.swordEquipped = false;
                            playerActions.pickaxeEquipped = false;
                            playerActions.axeEquipped = false;
                            break;
                        }
                        // if bool is false it will make the bool true and others false
                        else
                        {
                            playerActions.swordEquipped = false;
                            playerActions.pickaxeEquipped = true;
                            playerActions.axeEquipped = false;
                            break;
                        }
                    }
                    // checks if bool isAxe is true in the item.
                    else if (items[x].isAxe)
                    {
                        // if bool is true it will make all bool false
                        if (playerActions.axeEquipped)
                        {
                            playerActions.swordEquipped = false;
                            playerActions.pickaxeEquipped = false;
                            playerActions.axeEquipped = false;
                            break;
                        }
                        // if bool is false it will make the bool true and others false
                        else
                        {
                            playerActions.swordEquipped = false;
                            playerActions.pickaxeEquipped = false;
                            playerActions.axeEquipped = true;
                            break;
                        }
                    }
                    // esle it will break the loop
                    else
                    {
                        break;
                    }
                }
            }
            found = false;
        }
    }
    
    // Function to load the crafting items
    public void LoadCraftingItems()
    {
        // loops through all the crafting items.
        for (int x = 0; x < craftingItems.Length; x++)
        {
            // makes an icon for the crafting item.
            GameObject justAdded = Instantiate(craftingItemIcon, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0), craftingInventoryGrid.transform);
            craftingItemIcons.Add(craftingItems[x].name, justAdded);
            uIInfo.CreateCraftingItemIcon(craftingItemIcons[craftingItems[x].name], craftingItems[x].image, true);
        }
    }

    // Function that will be called when you click on a crafting item that you can interact with
    public void InteractionCrafting(GameObject itemIcon)
    {
        // sets the itemname to none
        string itemname = "none";
        bool found = false;
        // loops through all the crafting item icons.
        foreach (var item in craftingItemIcons)
        {
            if (item.Value == itemIcon)
            {
                // sets itemname to item.key name and set bool found to true
                itemname = item.Key;
                found = true;
                selectedCraftingIcon = itemIcon;
                break;
            }
        }
        // checks if found is true
        if (found)
        {
            // loops through all the crafting items.
            for (int x = 0; x < craftingItems.Length; x++)
            {
                // checks if the names are the same.
                if (craftingItems[x].name == itemname)
                {
                    // set the crafting item to the selected crafting item.
                    selectedCraftingItem = craftingItems[x];
                    string text = "";
                    // loops through all the items you need for the crafting item
                    for (int t = 0; t < craftingItems[x].needItemName.Length; t++)
                    {
                        int iGotAmount = 0;
                        // loops through all the items.
                        for (int y = 0; y < items.Length; y++)
                        {
                            // checks if the names are the same
                            if (items[y].name == craftingItems[x].needItemName[t])
                            {
                                // set the amount you have
                                iGotAmount = items[y].amount;
                                break;
                            }
                        }
                        // adds text to the full text.
                        text += craftingItems[x].needItemName[t] + ": " + iGotAmount + "/" + craftingItems[x].needItemAmount[t] + "\n";
                    }
                    // sets the full text to a info text.
                    uIInfo.ShowCraftingInfo(craftingItems[x].image, text, craftingItems[x].name);
                    break;
                }
            }
            found = false;
        }
    }

    // function for crafting
    public void Craft()
    {
        int enough = 0;
        // loops through all the items you need for the crafting item
        for (int x = 0; x < selectedCraftingItem.needItemName.Length; x++)
        {
            // loops through all items
            for (int y = 0; y < items.Length; y++)
            {
                // checks if the names are the same and the amount is not 0
                if (items[y].name == selectedCraftingItem.needItemName[x] && items[y].amount - selectedCraftingItem.needItemAmount[x] >= 0)
                {
                    enough++;
                    break;
                }
            }
        }

        // checks if you have enough items to craft the crafting item
        if (enough == selectedCraftingItem.needItemName.Length)
        {
            // adds the items to your inventory
            Additem(selectedCraftingItem.name, selectedCraftingItem.amountGetting);
            // removes the items you used
            for (int x = 0; x < selectedCraftingItem.needItemName.Length; x++)
            {
                Removeitem(selectedCraftingItem.needItemName[x], selectedCraftingItem.needItemAmount[x]);
            }
            // calls InteractionCrafting function to update displayed amount.
            InteractionCrafting(selectedCraftingIcon);
        }
    }
}
