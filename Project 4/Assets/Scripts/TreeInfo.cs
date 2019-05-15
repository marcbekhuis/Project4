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
        hits = Random.Range(hits - 1, hits + 1);
        currenthits = hits;
        for (int x = 0; x < itemsAmount.Length; x++)
        {
            itemsAmount[x] = Random.Range(itemsAmount[x] - 1, itemsAmount[x] + 1);
        }
    }
}
