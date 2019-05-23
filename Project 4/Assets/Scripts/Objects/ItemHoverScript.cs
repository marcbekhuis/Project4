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
        //Makes the object go up until it goes over the amount of time
        if (timer < amountTime)
        {
            transform.Translate(0, speed, 0);
            timer++;
        }
        //makes the object go down until it goes over amount of time times 2
        else if (timer < amountTime * 2)
        {
            transform.Translate(0, -speed, 0);
            timer++;
        }
        //resets the timer if it goes over timer times 2
        else if (timer >= amountTime * 2)
        {
            timer = 0;
        }
    }
}