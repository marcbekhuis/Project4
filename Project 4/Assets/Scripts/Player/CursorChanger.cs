﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Texture2D defaultPointer;
    public Texture2D swordPointer;
    public Texture2D axePointer;
    public Texture2D pickaxePointer;
    public CursorMode curMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    public PlayerActions playerActions;



    private void Start()
    {
        //Forces the defaultPointer texture on the cursor
        Cursor.SetCursor(defaultPointer, hotSpot, curMode);
    }
    private void Update()
    {
        //Runs as long as the player's allowAction state is true and gamePaused is not true.
        if (playerActions.allowAction && !playerActions.gamePaused)
        {
            //Checks conditions and changes the cursor texture when certain booleans are met
            if (!playerActions.axeEquipped && !playerActions.pickaxeEquipped && !playerActions.swordEquipped)
            {
                Cursor.SetCursor(defaultPointer, hotSpot, curMode);
            }
            else if (playerActions.axeEquipped)
            {
                Cursor.SetCursor(axePointer, hotSpot, curMode);
            }
            else if (playerActions.pickaxeEquipped)
            {
                Cursor.SetCursor(pickaxePointer, hotSpot, curMode);
            }
            else if (playerActions.swordEquipped)
            {
                Cursor.SetCursor(swordPointer, hotSpot, curMode);
            }
        }
        else
        {
            Cursor.SetCursor(null, hotSpot, curMode);
        }
    
    }

}
