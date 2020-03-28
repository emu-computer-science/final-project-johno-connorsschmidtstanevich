using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float moveForce = 20;
    public float maxSpeed = 10;
    public float jumpForce = 700;
    public Transform groundCheck;

    private float hForce = 1;
    private Rigidbody2D rb2d;
    private bool isAlive = true;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        //animator.SetBool("IdleRight", true);
    }

    
    void Update()
    {
        animator.SetFloat("Speed", rb2d.velocity.x);
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            if (Input.GetKey("right"))
            {
                rb2d.AddForce(Vector2.right * hForce * moveForce);
                if (rb2d.velocity.x > maxSpeed)
                    rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
                animator.SetBool("Right", true);
            }
            else if (Input.GetKey("left"))
            {
                rb2d.AddForce(Vector2.left * hForce * moveForce);
                if (rb2d.velocity.x > maxSpeed)
                    rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
                animator.SetBool("Right", false);
            }
            

            if (Input.GetKeyDown("space")) 
            {
                rb2d.AddForce(new Vector2(0, jumpForce));
            }
        }
    }
}
