using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInfo : MonoBehaviour
{
    public int hits = 3;
    public int currenthits;
    public string[] itemsString;
    public int[] itemsAmount;

    // Start is called before the first frame update
    void Start()
    {
        // randomizes the amount of hits a tree needs to get destroyed.
        hits = Random.Range(hits - 1, hits + 1);
        currenthits = hits;
        // loops through all the items you get from the tree
        for (int x = 0; x < itemsAmount.Length; x++)
        {
            // adds the item to your inventory
            itemsAmount[x] = Random.Range(itemsAmount[x] - 1, itemsAmount[x] + 1);
        }
    }
}
