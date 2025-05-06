using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    float move;
    public bool isGrounded;
    Rigidbody2D rb2d;
    Animator animator;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }      
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);
        animator.SetFloat("xVelocity", Math.Abs(rb2d.linearVelocity.x));
        animator.SetFloat("yVelocity", rb2d.linearVelocity.y);

        // jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", !isGrounded);
            Debug.Log("Jump"); //for debugging purpose
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
       if (other.gameObject.CompareTag("Ground"))
        { isGrounded = true; }
    }
    
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        { isGrounded = false; }
    }
    

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { isGrounded = true; }
    }
    */


}
