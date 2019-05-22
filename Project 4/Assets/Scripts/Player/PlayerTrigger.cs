using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private void OnCollisionStay2D(Collision2D collision)
    {
        playerMovement.inAir = false;
    }
}
