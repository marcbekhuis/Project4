using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSceneCloudScroller : MonoBehaviour
{
    public Rigidbody2D rb2D;
    [SerializeField] int speed;

    // Start is called before the first frame update
    void Start()
    {
        rb2D.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.velocity = new Vector3(-speed, 0, 0);
        if (transform.position.x <= -13)
        {
            transform.position = new Vector3(13, 0, 0);
        }
    }
}
