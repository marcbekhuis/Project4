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
    PlayerInvetory playerInvetory;
    public bool allowAction = true;
    public bool gamePaused = false;
    GameObject overlappingTree;
    public GameObject cursor;

    public GameObject swordBox;
    public bool swordEquipped = false;
    public bool axeEquipped = false;
    public bool pickaxeEquipped = false; 
    public int offsetX;
    public int offsetY;
    float actiondelay;

    private void Start()
    {
        playerInvetory = GetComponent<PlayerInvetory>();
    }

    private void FixedUpdate()
    {
      cursor.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + offsetX, Camera.main.ScreenToWorldPoint(Input.mousePosition).y + offsetY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (infoBook.activeSelf)
            {
                infoBook.SetActive(false);
                allowAction = true;
            }
            else
            {
                infoBook.SetActive(true);
                allowAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);
                allowAction = true;
            }
            else
            {
                inventory.SetActive(true);
                if (playerInvetory.selectedCraftingIcon != null)
                {
                    playerInvetory.InteractionCrafting(playerInvetory.selectedCraftingIcon);
                }
                allowAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                allowAction = true;
                gamePaused = false;
            }
            else
            {
                pauseMenu.SetActive(true);
                allowAction = false;
                gamePaused = true;
            }
        }
        if (actiondelay < Time.time)
        {
            if (axeEquipped || !axeEquipped && !pickaxeEquipped && !swordEquipped)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction)
                {
                    if (overlappingTree != null)
                    {
                        TreeInfo treeInfo = overlappingTree.GetComponent<TreeInfo>();
                        for (int x = 0; x < treeInfo.itemsAmount.Length; x++)
                        {
                            playerInvetory.Additem(treeInfo.itemsString[x], treeInfo.itemsAmount[x] / treeInfo.hits);
                        }
                        treeInfo.currenthits--;
                        actiondelay = Time.time + 1;
                        if (treeInfo.currenthits <= 0)
                        {
                            Destroy(overlappingTree);
                        }
                    }
                }

                if (!axeEquipped && !pickaxeEquipped && !swordEquipped)
                {

                    if (Input.GetKeyDown(KeyCode.Mouse1) && allowAction)
                    {
                        if (playerInvetory.selectedItem.name != "")
                        {
                            if (playerInvetory.selectedItem.amount != 0)
                            {
                                Vector3Int cellpos = tilemap.WorldToCell(new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0));
                                if (Vector3.Distance(this.transform.position, cellpos) <= 3)
                                {
                                    if (!tilemap.HasTile(cellpos))
                                    {
                                        if (cellpos != this.transform.position && cellpos != new Vector3(this.transform.position.x, this.transform.position.y - 1, 0))
                                        {
                                            if (tilemap.HasTile(new Vector3Int(cellpos.x - 1, cellpos.y, 0)) || tilemap.HasTile(new Vector3Int(cellpos.x + 1, cellpos.y, 0)) || tilemap.HasTile(new Vector3Int(cellpos.x, cellpos.y - 1, 0)) || tilemap.HasTile(new Vector3Int(cellpos.x, cellpos.y + 1, 0)))
                                            {
                                                playerInvetory.Removeitem(playerInvetory.selectedItem.name, 1);
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
            else if (pickaxeEquipped)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction)
                {


                    Vector3Int cellpos = tilemap.WorldToCell(new Vector3(cursor.transform.position.x, cursor.transform.position.y, 0));

                    if (Vector3.Distance(this.transform.position, cellpos) <= 3)
                    {
                        if (tilemap.HasTile(cellpos))
                        {
                            switch (tilemap.GetTile(cellpos).name)
                            {
                                case "Grass01":
                                    playerInvetory.Additem("Grass", 1);
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Grass02":
                                    playerInvetory.Additem("Grass", 1);
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Dirt01":
                                    playerInvetory.Additem("Dirt", 1);
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Dirt02":
                                    playerInvetory.Additem("Dirt", 1);
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "Stone01":
                                    playerInvetory.Additem("Stone", 1);
                                    tilemap.SetTile(cellpos, null);
                                    break;
                                case "DirtStone01":
                                    playerInvetory.Additem("Stone", 1);
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
            else if (swordEquipped)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction)
                {
                    swordBox.SetActive(true);
                }
                if (Input.GetKeyUp(KeyCode.Mouse0) && allowAction)
                {
                    swordBox.SetActive(false);
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            overlappingTree = collision.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tree"))
        {
            overlappingTree = null;
        }
    }
}
