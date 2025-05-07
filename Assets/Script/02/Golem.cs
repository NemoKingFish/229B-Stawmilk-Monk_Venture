using UnityEngine;

public class Golem : MonoBehaviour
{
    [SerializeField] float hp = 100f;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        Debug.Log("Golem took damage! HP = " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Golem died!");
        Destroy(gameObject);
    }
}