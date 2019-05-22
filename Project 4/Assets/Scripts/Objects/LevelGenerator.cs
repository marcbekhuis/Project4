using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public int mapSize;
    int negHalfMapSize;
    int PosHalfMapSize;
    int floorBlockHeight = 60;
    List<int> floorTilesHeight = new List<int>();

    public TileBase[] grass;
    public TileBase[] dirt;
    public TileBase[] dirtToGrass;
    public TileBase[] stone;
    [Space]
    public GameObject[] kapokTrees;

    // Start is called before the first frame update
    void Start()
    {
        int negHalfMapSize = mapSize / 2 * -1;
        int height = 1000;

        for (int x = 0; x < mapSize; x++)
        {
            switch (Random.Range(0,4))
            {
                case 0:
                    floorBlockHeight--;
                    break;
                case 1:
                    floorBlockHeight++;
                    break;
                default:
                    break;
            }
            for (int y = 0; y > -500; y--)
            {
                if (y == 0)
                {
                    tilemap.SetTile(new Vector3Int(negHalfMapSize + x, floorBlockHeight + y,0), grass[Random.Range(0,grass.Length)]);
                    floorTilesHeight.Add(floorBlockHeight + y);
                }
                else if (y == -1)
                {
                    tilemap.SetTile(new Vector3Int(negHalfMapSize + x, floorBlockHeight + y, 0), dirt[Random.Range(0, dirt.Length)]);
                }
                else if (y == -2)
                {
                    tilemap.SetTile(new Vector3Int(negHalfMapSize + x, floorBlockHeight + y, 0), dirtToGrass[Random.Range(0, dirtToGrass.Length)]);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(negHalfMapSize + x, floorBlockHeight + y, 0), stone[Random.Range(0, stone.Length)]);
                }
                if ((floorBlockHeight + y) <= -10)
                {
                    height = floorBlockHeight + y;
                    break;
                }
            }
            switch (Random.Range(0, 4))
            {
                case 0:
                        Instantiate(kapokTrees[Random.Range(0, kapokTrees.Length)], new Vector3(negHalfMapSize + x, floorTilesHeight[x] + 1, 0), new Quaternion(0, 0, 0, 0));
                    break;
                default:
                    break;
            }
        }
    }
}
