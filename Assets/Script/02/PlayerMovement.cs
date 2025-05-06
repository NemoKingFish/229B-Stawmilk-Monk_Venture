using System;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private float move;
    public bool isGrounded;

    private Rigidbody2D rb2d;
    private Animator animator;
    private bool isFacingRight = true;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        move = Input.GetAxis("Horizontal");
    }

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y); // ✅ แก้ตรงนี้

        if (animator != null)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(rb2d.linearVelocity.x)); // ✅ Math.Abs → Mathf.Abs
            animator.SetFloat("yVelocity", rb2d.linearVelocity.y);
        }
        //flip
        FlipSprite();

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            animator?.SetBool("isJumping", true);
            Debug.Log("Jump"); //for debugging purpose
        }
    }

    void FlipSprite()
    {
        if (isFacingRight && move < 0f || !isFacingRight && move > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator?.SetBool("isJumping", false); 
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}

