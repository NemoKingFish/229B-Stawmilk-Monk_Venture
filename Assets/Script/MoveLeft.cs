using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 10f;
    private PlayerController playerController;

    private void Start()
    {
        var go = GameObject.Find("Player");
        playerController = go.GetComponent<PlayerController>();
    }
    void Update()
    {
        if (playerController.isGameOver == false)
        { transform.Translate(Vector3.left * speed * Time.deltaTime); }
    }
}
