using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActions : MonoBehaviour
{
    public GameObject infoBook;
    public Tilemap tilemap;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (infoBook.activeSelf)
            {
                infoBook.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                infoBook.SetActive(true);
                Time.timeScale = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            tilemap.SetTile(new Vector3Int((int)Input.mousePosition.x, (int)Input.mousePosition.y, 0), null);
            Debug.Log(tilemap.HasTile(new Vector3Int((int)Input.mousePosition.x, (int)Input.mousePosition.y, 0)));
            Debug.Log(Input.mousePosition);
        }
    }
}
