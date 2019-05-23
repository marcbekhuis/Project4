using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public PlayerMovement playerMovement;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Checks if there's collision with an object tagged as "Albetros"
        if (collision.gameObject.CompareTag("Albetros"))
        {
            //Changes the bool fly in the playerMovement script to true
            playerMovement.fly = true;
            collision.gameObject.transform.parent = this.transform;

            //Will try to destroy the CloudScript and RigidBody 2D on collision
            try
            {
                Destroy(collision.gameObject.GetComponent<CloudsScript>());
                Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            }
            //Will perform the code in the catch section if it gives an error
            catch
            {

            }
            try
            {
                //Will set the gravityScale to 0.05f;
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.05f;
            }
            catch
            {

            }
        }
    }
}
