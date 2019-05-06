using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float speed = 300;
    public float jumpForce = 1000;
    public bool inAir = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed,rigidbody.velocity.y);
        if (!inAir)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rigidbody.AddForce(new Vector2(0, jumpForce * Time.fixedDeltaTime));
                inAir = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        inAir = false;
        Debug.Log("check");
    }
}
