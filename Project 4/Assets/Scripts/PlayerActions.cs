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

    private void Start()
    {
        playerInvetory = GetComponent<PlayerInvetory>();
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
                allowAction = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                pauseMenu.SetActive(false);
                allowAction = true;
            }
            else
            {
                pauseMenu.SetActive(true);
                allowAction = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && allowAction)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (tilemap.HasTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0)))
            {
                switch (tilemap.GetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0)).name)
                {
                    case "Grass01":
                        playerInvetory.Additem("Grass", 1);
                        tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), null);
                        break;
                    case "Grass02":
                        playerInvetory.Additem("Grass", 1);
                        tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), null);
                        break;
                    case "Dirt01":
                        playerInvetory.Additem("Dirt", 1);
                        tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), null);
                        break;
                    case "Dirt02":
                        playerInvetory.Additem("Dirt", 1);
                        tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), null);
                        break;
                    case "Stone01":
                        playerInvetory.Additem("Stone", 1);
                        tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), null);
                        break;
                    case "DirtStone01":
                        playerInvetory.Additem("Stone", 1);
                        tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), null);
                        break;
                    default:
                        tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), null);
                        break;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1) && allowAction)
        {
            if (playerInvetory.selectedItem.name != "")
            {
                if (playerInvetory.selectedItem.amount != 0)
                {
                    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (!tilemap.HasTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0)))
                    {
                        if (tilemap.HasTile(new Vector3Int((int)mousePosition.x - 1, (int)mousePosition.y, 0)) || tilemap.HasTile(new Vector3Int((int)mousePosition.x + 1, (int)mousePosition.y, 0)) || tilemap.HasTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y - 1, 0)) || tilemap.HasTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y + 1, 0)))
                        {
                            playerInvetory.Removeitem(playerInvetory.selectedItem.name, 1);
                            tilemap.SetTile(new Vector3Int((int)mousePosition.x, (int)mousePosition.y, 0), playerInvetory.selectedItem.tiles[Random.Range(0, playerInvetory.selectedItem.tiles.Length)]);
                        }
                    }
                }
            }
        }
    }
}
