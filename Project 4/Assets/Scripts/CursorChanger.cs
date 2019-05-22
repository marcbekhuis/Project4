using System.Collections;
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
        Cursor.SetCursor(defaultPointer, hotSpot, curMode);
    }
    private void Update()
    {
        if (playerActions.axeEquipped)
        {
            Cursor.SetCursor(axePointer, hotSpot, curMode);
        }
        if(playerActions.pickaxeEquipped)
        {
            Cursor.SetCursor(pickaxePointer, hotSpot, curMode);
        }
        if (playerActions.swordEquipped)
        {
            Cursor.SetCursor(swordPointer, hotSpot, curMode);
        }
    
    }

}
