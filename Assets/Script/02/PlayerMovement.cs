using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float hp = 100f;
    [SerializeField] float Speed;
    [SerializeField] float JumpForce;
    private float move;

    float time;
    public bool isCooldown = false;
    public bool isGrounded;
    private Rigidbody2D rb2d;

    private Animator animator;
    private bool isFacingRight = true;

    [SerializeField] private Slider healthBar;

    void Start()
    {   
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        move = Input.GetAxis("Horizontal");

        if (healthBar != null)
        {
            healthBar.maxValue = hp;
            healthBar.value = hp;
        }
    }

    void Update()
    {
        time = Time.deltaTime;

        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);
        if (animator != null)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(rb2d.linearVelocity.x));
            animator.SetFloat("yVelocity", rb2d.linearVelocity.y);
            
        }
        FlipSprite();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            animator?.SetBool("isJumping", true);
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

        if (other.gameObject.CompareTag("Monster"))
        {
            TakeDamage(10f);
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
    void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Player took damage! HP = " + hp);

        if (hp <= 0)
        {
            Die();
        }

        if (healthBar != null)
        {
            healthBar.value = hp;
        }
    }
    void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }
}

