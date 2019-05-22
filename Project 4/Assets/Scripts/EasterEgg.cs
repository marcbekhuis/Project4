﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public PlayerInvetory playerInvetory;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Albetros"))
        {
            playerInvetory.albatros = true;
            collision.gameObject.transform.parent = this.transform;
            try
            {
                Destroy(collision.gameObject.GetComponent<CloudsScript>());
                Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            }
            catch
            {

            }
        }
    }
}
