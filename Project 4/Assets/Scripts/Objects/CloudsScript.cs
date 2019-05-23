using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsScript : MonoBehaviour
{
    float scrollSpeed;
    public Rigidbody2D rb;

    private void Start()
    {
        //Sets a random number within a certain range for the variable scrollSpeed
        scrollSpeed = Random.Range(-1, -4);
    }
    private void Update()
    {
        //Sets velocity to the rigidbody of this object
        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks collision with the game object tagged as "EndWall" and destroys the object with this script attached
        if (collision.gameObject.CompareTag("EndWall"))
        {
            Destroy(this.gameObject);
        }
    }
}