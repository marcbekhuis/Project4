using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoverScript : MonoBehaviour
{
    [SerializeField] private float amountTime;
    [SerializeField] private float speed;
    private float timer;

    private void Update()
    {
        if (timer < amountTime)
        {
            transform.Translate(0, speed, 0);
            timer++;
        }
        else if (timer < amountTime * 2)
        {
            transform.Translate(0, -speed, 0);
            timer++;
        }
        else if (timer >= amountTime * 2)
        {
            timer = 0;
        }
    }
}