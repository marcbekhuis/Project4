using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHoverScript : MonoBehaviour
{
    public float hoverSpeed;
    public float hoverOffset;
    Vector3 location;

    int timesUp;
    int timesDown;
    bool direction = false;

    private void Start()
    {
        location = this.transform.position;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.transform.position.y >= location.y - 10)
        {
            direction = true;
        }
        else if (this.transform.position.y >= location.y + 10)
        {
            direction = false;
        }

        if (direction)
        {
            this.transform.Translate(new Vector3(0,hoverSpeed * Time.fixedDeltaTime, 0));
        }
        else
        {
            this.transform.Translate(new Vector3(0, hoverSpeed * Time.fixedDeltaTime * -1, 0));
        }
    }
}
