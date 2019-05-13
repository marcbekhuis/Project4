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
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerActions = GetComponent<PlayerActions>();
    }

    private void FixedUpdate()
    {
            {
                if (Input.GetKey(KeyCode.A))
                {
                    if (!Input.GetKey(KeyCode.D))
                    {
                        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                        {
                            rigidbody.velocity = new Vector2(-1 * Time.fixedDeltaTime * crouchSpeed, rigidbody.velocity.y);
                        }
                        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
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
                else if (Input.GetKey(KeyCode.D))
                {
                    if (!Input.GetKey(KeyCode.A))
                    {
                        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
                        {
                            rigidbody.velocity = new Vector2(1 * Time.fixedDeltaTime * crouchSpeed, rigidbody.velocity.y);
                        }
                        else if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                        {
                            rigidbody.velocity = new Vector2(1 * Time.fixedDeltaTime * runSpeed, rigidbody.velocity.y);
                        }
                        else
                        {
                            rigidbody.velocity = new Vector2(1 * Time.deltaTime * walkSpeed, rigidbody.velocity.y);
                        }
                        playerImage.transform.localScale = new Vector3(-1, 1, 1);
                    }
                }else
                {
                    rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
                }
            }
            if (!inAir)
            {
                if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                {
                    rigidbody.AddForce(new Vector2(0, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
                    inAir = true;
                }
            }
            inAir = !Physics2D.OverlapBox(this.transform.position, new Vector2(0.45f,0.01f),0, 1 << LayerMask.NameToLayer("Solid"));
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
