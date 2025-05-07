using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float delay = 3f;

    [SerializeField] float damage = 20f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, delay);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Golem"))
        {
            Golem golem = collision.gameObject.GetComponent<Golem>();
            if (golem != null)
            {
                golem.TakeDamage(damage);
            }
            Destroy(gameObject); // ทำลายกระสุนเมื่อชน
        }
    }
}

