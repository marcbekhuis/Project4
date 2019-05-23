using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Transform respawnPoint;

    //Calls function when the trigger is entered
    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        GameObject hitObj = collider.gameObject;
        //Detects if the entered object has the tag "Player"
        if (hitObj.tag == "Player")
        {
            //Sends the plater to the transform of the respawn point
            player.transform.position = respawnPoint.transform.position;
        }
    }

}
