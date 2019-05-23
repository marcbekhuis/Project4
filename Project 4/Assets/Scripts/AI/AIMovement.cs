using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Animator animator;

    [Space]

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
        // gets the rigidbody from the object this script is on.
        rigidbody = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        // sets the bool for the animation
        animator.SetBool("Jump", Physics2D.OverlapBox(this.transform.position + new Vector3(jumpBoxPos.x * direction, jumpBoxPos.y, 0), jumpBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")));
        // checks if on ground and against a 1 block high.
        if (Physics2D.OverlapBox(this.transform.position, floorBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")) && Physics2D.OverlapBox(this.transform.position + new Vector3(jumpBoxPos.x * direction, jumpBoxPos.y, 0), jumpBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")) && !Physics2D.OverlapBox(this.transform.position + new Vector3(wallBoxPos.x * direction, wallBoxPos.y, 0), wallBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")))
        {
            // jump
            rigidbody.AddForce(new Vector2(0, jumpForce * Time.fixedDeltaTime), ForceMode2D.Impulse);
        }
        // checks if against a wall
        if (Physics2D.OverlapBox(this.transform.position + new Vector3(wallBoxPos.x * direction, wallBoxPos.y, 0), wallBoxSize, 0, 1 << LayerMask.NameToLayer("Solid")))
        {
            // flips AI around
            direction *= -1;
            this.transform.localScale = new Vector3(direction, 1, 1);
        }
        // checks if rethink time has passed
        if (rethinkTime < Time.time)
        {
            // sets the direction the AI is moving in to a random direction
            if (Random.Range(0,2) == 0)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            // flips object
            this.transform.localScale = new Vector3(direction, 1, 1);
            rethinkTime = Time.time + Random.Range(4,7);
        }
        // Moves AI
        rigidbody.velocity = new Vector2(speed * Random.Range(0,(float)direction) * Time.fixedDeltaTime, rigidbody.velocity.y);

        // checks for which animation to play
        if (rigidbody.velocity.x != 0)
        {
            //set set animation bool
            animator.SetBool("Walk", true);
        }
        else
        {
            //set set animation bool
            animator.SetBool("Walk", false);
        }
    }

    // Check if for collision enter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // checks if collider is player
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("AI"))
        {
            // flips AI
            direction *= -1;
            this.transform.localScale = new Vector3(direction, 1, 1);
        }
    }
}
