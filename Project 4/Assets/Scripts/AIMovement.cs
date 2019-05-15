using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public float speed = 300;
    public float jumpForce = 150;
    public Vector2 jumpBoxSize = new Vector2(0.01f, 0.45f);
    public Vector2 wallBoxSize = new Vector2(0.01f, 0.45f);
    public Vector2 floorBoxSize = new Vector2(4.3f, 0.01f);
    public Vector3 jumpBoxPos = new Vector3(2.4f, 0.33f, 0);
    public Vector3 wallBoxPos = new Vector3(2.4f, 1.6f, 0);

    Rigidbody2D rigidbody;
    float rethinkTime;
    int direction;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if (Physics2D.OverlapBox(this.transform.position, floorBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")) && Physics2D.OverlapBox(this.transform.position + new Vector3(jumpBoxPos.x * direction, jumpBoxPos.y, 0), jumpBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")) && !Physics2D.OverlapBox(this.transform.position + new Vector3(wallBoxPos.x * direction, wallBoxPos.y, 0), wallBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")))
        {
            rigidbody.AddForce(new Vector2(0, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
        if (Physics2D.OverlapBox(this.transform.position + new Vector3(wallBoxPos.x * direction, wallBoxPos.y, 0), wallBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")))
        {
            direction *= -1;
            this.transform.localScale = new Vector3(direction, 1, 1);
        }
        if (rethinkTime < Time.time)
        {
            if (Random.Range(0,2) == 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            this.transform.localScale = new Vector3(direction, 1, 1);
            rethinkTime = Time.time + Random.Range(4,7);
        }
        rigidbody.velocity = new Vector2(speed * Random.Range(0,(float)direction) * Time.fixedDeltaTime, rigidbody.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            direction *= -1;
            this.transform.localScale = new Vector3(direction, 1, 1);
        }
    }
}
