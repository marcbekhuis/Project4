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
    public GameObject playerImage;
    PlayerActions playerActions;
    public Animator animator;
    public bool fly = false;
    private void Start()
    {
        Cursor.visible = false;

        rigidbody = GetComponent<Rigidbody2D>();
        playerActions = GetComponent<PlayerActions>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
        {
            if (!Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.JoystickButton1))
                {
                    rigidbody.velocity = new Vector2(-1 * Time.fixedDeltaTime * crouchSpeed, rigidbody.velocity.y);
                }
                else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.JoystickButton2))
                {
                    rigidbody.velocity = new Vector2(-1 * Time.fixedDeltaTime * runSpeed, rigidbody.velocity.y);
                }
                else
                {
                    rigidbody.velocity = new Vector2(-1 * Time.deltaTime * walkSpeed, rigidbody.velocity.y);
                }
                playerImage.transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("Horizontal") > 0)
        {
            if (!Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("Horizontal") < 0)
            {
                if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl) || Input.GetKey(KeyCode.Joystick1Button1))
                {
                    rigidbody.velocity = new Vector2(1 * Time.fixedDeltaTime * crouchSpeed, rigidbody.velocity.y);
                }
                else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.JoystickButton2))
                {
                    rigidbody.velocity = new Vector2(1 * Time.fixedDeltaTime * runSpeed, rigidbody.velocity.y);
                }
                else
                {
                    rigidbody.velocity = new Vector2(1 * Time.deltaTime * walkSpeed, rigidbody.velocity.y);
                }
                playerImage.transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
        if (!fly)
        {
            if (!inAir)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0))
                {
                    rigidbody.AddForce(new Vector2(0, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
                    inAir = true;
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton0))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 1 * Time.fixedDeltaTime * jumpForce);
            }
            else if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.JoystickButton0))
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, -1 * Time.fixedDeltaTime * jumpForce);
            }
        }
        inAir = !Physics2D.OverlapBox(this.transform.position, new Vector2(0.45f, 0.01f), 0, 1 << LayerMask.NameToLayer("Solid"));
    }

    private void Update()
    {
        if (rigidbody.velocity.x != 0)
        {
            animator.SetBool("walkingAnim", true);
        }
        else
        {
            animator.SetBool("walkingAnim", false);
        }
        if (inAir == true)
        {
            animator.SetBool("jumpingAnim", true);
        }
        else
        {
            animator.SetBool("jumpingAnim", false);
        }
    }
}
