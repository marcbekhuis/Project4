using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActions : MonoBehaviour
{
    public GameObject infoBook;
    public GameObject inventory;
    public GameObject pauseMenu;
    public Tilemap tilemap;
    public GameObject player;
    public GameObject cursor;
    public GameObject swordBox;
    PlayerInvetory playerInvetory;
    GameObject overlappingTree;

    public bool allowAction = true;
    public bool gamePaused = false;
    public bool swordEquipped = false;
    public bool axeEquipped = false;
    public bool pickaxeEquipped = false; 
    public int offsetX;
    public int offsetY;
    public int controllerMode = 0;
    public int cursorSpeed;
    int xAxis;
    int yAxis;
    float actiondelay;

    private void Start()
    {
        cursor.transform.position = new Vector3(0, 0, 0);
        // gets PlayerInventory from the object this script is on.
        playerInvetory = GetComponent<PlayerInvetory>();
        controllerMode = PlayerPrefs.GetInt("controllerMode");
    }

    private void FixedUpdate()
    {
        // checks what controllerMode is set to.
        if (controllerMode == 0)
        {
            // sets the position of the cursor gameobject.
            cursor.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + offsetX, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + offsetY, 0);
        }
        else
        {
            // checks for inputs to move the cursor object
            if (Input.GetAxis("HorizontalController") > 0.25)
            {
                xAxis++;
                cursor.transform.position = new Vector3(cursorSpeed * xAxis * Time.deltaTime, cursor.transform.position.y, 0);
            }
            else if (Input.GetAxis("HorizontalController") < -0.25)
            {
                xAxis--;
                cursor.transform.position = new Vector3(cursorSpeed * xAxis * Time.deltaTime, cursor.transform.position.y, 0);
            }

            if (Input.GetAxis("VerticalController") > 0.25)
            {
                yAxis--;
                cursor.transform.position = new Vector3(cursor.transform.position.x, cursorSpeed * yAxis * Time.deltaTime, 0);
            }
            else if (Input.GetAxis("VerticalController") < -0.25 )
            {
                yAxis++;
                cursor.transform.position = new Vector3(cursor.transform.position.x, cursorSpeed * yAxis * Time.deltaTime, 0);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // checks if you pressed I
        if (Input.GetKeyDown(KeyCode.I))
        {
            // checks if gameobject is active
            if (infoBook.activeSelf)
            {
                // sets gameobject active to false
                infoBook.SetActive(false);
                allowAction = true;
            }
            else
            {
                // sets gameobject active to true
                infoBook.SetActive(true);
                allowAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            // checks if gameobject is active
            if (inventory.activeSelf)
            {
                // sets gameobject active to false
                inventory.SetActive(false);
                allowAction = true;
            }
            else
            {
                // sets gameobject active to true
                inventory.SetActive(true);
                if (playerInvetory.selectedCraftingIcon != null)
                {
                    playerInvetory.InteractionCrafting(playerInvetory.selectedCraftingIcon);
                }
                allowAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.JoystickButton6))
        {
            // checks if gameobject is active
            if (pauseMenu.activeSelf)
            {
                // sets gameobject active to false
                pauseMenu.SetActive(false);
                allowAction = true;
                gamePaused = false;
            }
            else
            {
                // sets gameobject active to true
                pauseMenu.SetActive(true);
                allowAction = false;
                gamePaused = true;
            }
        }
        // checks if delay for action is passed
        if (actiondelay < Time.time)
        {
            // checks if axe or notting is equiped
            if (axeEquipped || !axeEquipped && !pickaxeEquipped && !swordEquipped)
            {
                // checks for input left mouse click
                if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction || Input.GetKeyDown(KeyCode.JoystickButton3) && allowAction)
                {
                    // checks if your overlapping a tree
                    if (overlappingTree != null)
                    {
                        // gets tree info from the overlapping tree.
                        TreeInfo treeInfo = overlappingTree.GetComponent<TreeInfo>();
                        // loops through the items you get from the tree and adds them to your inventory.
                        for (int x = 0; x < treeInfo.itemsAmount.Length; x++)
                        {
                            playerInvetory.Additem(treeInfo.itemsString[x], treeInfo.itemsAmount[x] / treeInfo.hits);
                        }
                        // removes a hit from the tree.
                        treeInfo.currenthits--;
                        actiondelay = Time.time + 1;
                        // destroys the tree.
                        if (treeInfo.currenthits <= 0)
                        {
                            Destroy(overlappingTree);
                        }
                    }
                }

                // check if you dont have anything equipped
                if (!axeEquipped && !pickaxeEquipped && !swordEquipped)
                {
                    // checks for input right mouse click
                    if (Input.GetKeyDown(KeyCode.Mouse1) && allowAction || Input.GetKeyDown(KeyCode.JoystickButton3) && allowAction)
                    {
                        // check if you have a item selected to build with.
                        if (playerInvetory.selectedItem.name != "")
                        {
                            // checks if the amount of the selected item isn't 0
                            if (playerInvetory.selectedItem.amount != 0)
                            {
                                // converts the world position to cell position.
                                Vector3Int cellpos = tilemap.WorldToCell(new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0));
                                // check if the distance is with in the range limit
                                if (Vector3.Distance(this.transform.position, cellpos) <= 3)
                                {
                                    // checks if the cell doesnt have a tile
                                    if (!tilemap.HasTile(cellpos))
                                    {
                                        // checks if the cell position isn't the same as the player
                                        if (cellpos != this.transform.position && cellpos != new Vector3(this.transform.position.x, this.transform.position.y - 1, 0))
                                        {
                                            // checks if there is a tile in the cells next to it.
                                            if (tilemap.HasTile(new Vector3Int(cellpos.x - 1, cellpos.y, 0)) || tilemap.HasTile(new Vector3Int(cellpos.x + 1, cellpos.y, 0)) || tilemap.HasTile(new Vector3Int(cellpos.x, cellpos.y - 1, 0)) || tilemap.HasTile(new Vector3Int(cellpos.x, cellpos.y + 1, 0)))
                                            {
                                                // removes the item from your inventory
                                                playerInvetory.Removeitem(playerInvetory.selectedItem.name, 1);
                                                // sets the tile to the tile you are building with
                                                tilemap.SetTile(cellpos, playerInvetory.selectedItem.tiles[Random.Range(0, playerInvetory.selectedItem.tiles.Length)]);
                                                actiondelay = Time.time + 1;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // checks if pickaxe is equipped
            else if (pickaxeEquipped)
            {
                // checks for input left mouse click
                if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction || Input.GetKeyDown(KeyCode.JoystickButton3) && allowAction)
                {
                    // converts the world position to cell position.
                    Vector3Int cellpos = tilemap.WorldToCell(new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0));

                    // check if the distance is with in the range limit
                    if (Vector3.Distance(this.transform.position, cellpos) <= 3)
                    {
                        // checks if the cell has a tile
                        if (tilemap.HasTile(cellpos))
                        {
                            // checks the tile name
                            switch (tilemap.GetTile(cellpos).name)
                            {
                                case "Grass01":
                                    // adds a item to your inventory
                                    playerInvetory.Additem("Grass", 1);
                                    // removes the tile
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Grass02":
                                    // adds a item to your inventory
                                    playerInvetory.Additem("Grass", 1);
                                    // removes the tile
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Dirt01":
                                    // adds a item to your inventory
                                    playerInvetory.Additem("Dirt", 1);
                                    // removes the tile
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Dirt02":
                                    // adds a item to your inventory
                                    playerInvetory.Additem("Dirt", 1);
                                    // removes the tile
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Stone01":
                                    // adds a item to your inventory
                                    playerInvetory.Additem("Stone", 1);
                                    // removes the tile
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "DirtStone01":
                                    // adds a item to your inventory
                                    playerInvetory.Additem("Stone", 1);
                                    // removes the tile
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Bedrock01":
                                    break;
                                default:
                                    tilemap.SetTile(cellpos, null);
                                    break;
                            }
                            actiondelay = Time.time + 0.1f;
                        }
                    }
                }
            }
            // checks if sword is equipped
            else if (swordEquipped)
            {
                // checks for input pressed left mouse click
                if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction || Input.GetKeyDown(KeyCode.JoystickButton3) && allowAction)
                {
                    // sets a damage box collider on
                    swordBox.SetActive(true);
                }
                // checks for input release left mouse click
                if (Input.GetKeyUp(KeyCode.Mouse0) && allowAction || Input.GetKeyDown(KeyCode.JoystickButton3) && allowAction)
                {
                    // sets a damage box collider off
                    swordBox.SetActive(false);
                }
            }
        }
    }

    // collision enter check
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check if your overlapping a tree.
        if (collision.gameObject.CompareTag("Tree"))
        {
            // sets overlapping tree
            overlappingTree = collision.gameObject;
        }
    }

    // collision exit check
    private void OnTriggerExit2D(Collider2D collision)
    {
        // check if your overlapping a tree.
        if (collision.gameObject.CompareTag("Tree"))
        {
            // sets overlapping tree
            overlappingTree = null;
        }
    }
}
