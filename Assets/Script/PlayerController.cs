using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Physics.gravity *= gravityMultiplier;
        playerAnim.SetFloat("Speed_f", 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (jumpAction.triggered && isOnGround && isGameOver == false )
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSfx, 1.0f);
            dirtFx.Stop();
        }
    }

    void OnCollisionEnter(Collision collision)
    {   if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtFx.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAudio.PlayOneShot(crashSfx);
            explosionFx.Play();
            dirtFx.Stop();
        }
    }
}
