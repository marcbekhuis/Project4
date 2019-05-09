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
        if (Input.GetAxis("Horizontal") <= 0)
        {
            playerImage.transform.localScale = new Vector3(1,1,1);
            
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            playerImage.transform.localScale = new Vector3(-1, 1, 1);
            
        }

       

        if (playerActions.allowAction)
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
        else
        {
            rigidbody.velocity = new Vector2(0,0);
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
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

    private void OnCollisionStay2D(Collision2D collision)
    {
        inAir = false;
    }
}
