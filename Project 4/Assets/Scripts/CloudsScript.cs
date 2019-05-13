using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsScript : MonoBehaviour
{
    float scrollSpeed;
    public Rigidbody2D rb;

    private void Start()
    {
        scrollSpeed = Random.Range(-1, -4);
    }
    private void Update()
    {
        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EndWall"))
        {
            Destroy(this.gameObject);
        }
    }
}