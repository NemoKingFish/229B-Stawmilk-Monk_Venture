using UnityEngine;
using UnityEngine.InputSystem;

public class Player02 : Character
{
    public float jumpForce = 10f;
    public float gravityMultiplier = 1f;

    private Rigidbody rb;
    private InputAction jumpAction;
    private bool isOnGround = true;
    public bool isGameOver = false;

    public Animator playerAnim;

    public AudioClip jumpSfx;
    public AudioClip crashSfx;
    public AudioSource playerAudio;

    public ParticleSystem explosionFx;
    public ParticleSystem dirtFx;

    // กำหนด Input Action จาก Inspector
    public InputActionReference jumpActionRef;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (jumpActionRef != null)
        {
            jumpAction = jumpActionRef.action;
            jumpAction.Enable();
        }

        // กำหนดค่าเริ่มต้นสำหรับ Player
        SetCharacter("Player1", 100);
    }

    void Start()
    {
        Physics.gravity *= gravityMultiplier;

        if (playerAnim != null)
        {
            playerAnim.SetFloat("Speed_f", 1.0f);
        }
    }

    void Update()
    {
        if (!isGameOver && isOnGround && jumpAction != null && jumpAction.triggered)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim?.SetTrigger("Jump_trig");
            if (playerAudio && jumpSfx)
                playerAudio.PlayOneShot(jumpSfx, 1.0f);
            dirtFx?.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtFx?.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnim?.SetBool("Death_b", true);

            if (playerAudio && crashSfx)
                playerAudio.PlayOneShot(crashSfx);
            explosionFx?.Play();
            dirtFx?.Stop();
        }
    }
}
