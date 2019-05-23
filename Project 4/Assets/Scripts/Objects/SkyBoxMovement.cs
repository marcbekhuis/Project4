using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxMovement : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void FixedUpdate()
    {
        // moves the skybox x position to follow the player.
        this.transform.position = new Vector3(player.transform.position.x, this.transform.position.y, 0);
    }
}
