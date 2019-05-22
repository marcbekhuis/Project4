using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public PlayerMovement playerMovement;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Albetros"))
        {
            playerMovement.fly = true;
            collision.gameObject.transform.parent = this.transform;
            try
            {
                Destroy(collision.gameObject.GetComponent<CloudsScript>());
                Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            }
            catch
            {

            }
            try
            {
                this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0.05f;
            }
            catch
            {

            }
        }
    }
}
