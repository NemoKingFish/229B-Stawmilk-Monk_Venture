using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float delay = 3f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Start()
    {
        Destroy(gameObject, delay);
    }
}

