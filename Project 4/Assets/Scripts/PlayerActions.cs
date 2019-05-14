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

    public int offsetX;
    public int offsetY;

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
        if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction)
        {
            if (overlappingTree != null)
            {
                playerInvetory.Additem("Wood", Random.Range(2,4));
                playerInvetory.Additem("Stick", Random.Range(4, 8));
                playerInvetory.Additem("Leave", Random.Range(2, 4));
                Destroy(overlappingTree);
            }
            if (Vector3.Distance(this.transform.position, cursor.transform.position) <= 200)
            {
                if (tilemap.HasTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0)))
                {
                    switch (tilemap.GetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0)).name)
                    {
                        case "Grass01":
                            playerInvetory.Additem("Grass", 1);
                            tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), null);
                            break;
                        case "Grass02":
                            playerInvetory.Additem("Grass", 1);
                            tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), null);
                            break;
                        case "Dirt01":
                            playerInvetory.Additem("Dirt", 1);
                            tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), null);
                            break;
                        case "Dirt02":
                            playerInvetory.Additem("Dirt", 1);
                            tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), null);
                            break;
                        case "Stone01":
                            playerInvetory.Additem("Stone", 1);
                            tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), null);
                            break;
                        case "DirtStone01":
                            playerInvetory.Additem("Stone", 1);
                            tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), null);
                            break;
                        default:
                            tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), null);
                            break;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && allowAction)
        {
            if (playerInvetory.selectedItem.name != "")
            {
                if (playerInvetory.selectedItem.amount != 0)
                {
                    if (!tilemap.HasTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0)))
                    {
                        if (new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0) != new Vector3Int((int)this.transform.position.x, (int)this.transform.position.y, 0) && new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0) != new Vector3Int((int)this.transform.position.x, (int)this.transform.position.y - 1, 0))
                        {
                            if (tilemap.HasTile(new Vector3Int((int)cursor.transform.position.x - 1, (int)cursor.transform.position.y, 0)) || tilemap.HasTile(new Vector3Int((int)cursor.transform.position.x + 1, (int)cursor.transform.position.y, 0)) || tilemap.HasTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y - 1, 0)) || tilemap.HasTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y + 1, 0)))
                            {
                                playerInvetory.Removeitem(playerInvetory.selectedItem.name, 1);
                                tilemap.SetTile(new Vector3Int((int)cursor.transform.position.x, (int)cursor.transform.position.y, 0), playerInvetory.selectedItem.tiles[Random.Range(0, playerInvetory.selectedItem.tiles.Length)]);
                            }
                        }
                    }
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
