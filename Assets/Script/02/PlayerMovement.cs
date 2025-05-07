using System;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float Speed;
    [SerializeField] float JumpForce;
    private float move;

    float time;
    public bool isCooldown = false;
    public bool isGrounded;
    private Rigidbody2D rb2d;

    private Animator animator;
    private bool isFacingRight = true;
    [SerializeField] private HealthBarController healthBar;

    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {   
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        move = Input.GetAxis("Horizontal");
        healthBar.Initialize(hp);
    }

    void Update()
    {
        time = Time.deltaTime;

        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);
        //null check
        if (animator != null)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(rb2d.linearVelocity.x));
            animator.SetFloat("yVelocity", rb2d.linearVelocity.y);
            
        }
        //flip
        FlipSprite();

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {                                 //JumpForce            //Force
            rb2d.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            animator?.SetBool("isJumping", true);
            
        }

        if (Input.GetButtonDown("Fire1") && !isCooldown)
        {
            Shoot();
            //animator.SetFloat("Throw",1f );
            //animator?.SetBool("isThrowing", true);
            Debug.Log("testkey");
        }
    }
    //flip
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

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        //animator.SetFloat("Throw", -0f);
        animator?.SetTrigger("Throw");
        Debug.Log("testkey");
    }

    //enter
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator?.SetBool("isJumping", false);          
        }
    }
    //out
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        healthBar.TakeDamage(dmg);
    }
}

