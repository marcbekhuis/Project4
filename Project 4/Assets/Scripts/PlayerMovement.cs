using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float walkSpeed = 250;
    public float runSpeed = 500;
    public float crouchSpeed = 100;
    public float jumpForce = 1000;
    public bool inAir = false;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * runSpeed, rigidbody.velocity.y);
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * crouchSpeed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(Input.GetAxis("Horizontal") * Time.fixedDeltaTime * walkSpeed, rigidbody.velocity.y);
        }
        if (!inAir)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                rigidbody.AddForce(new Vector2(0, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
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
