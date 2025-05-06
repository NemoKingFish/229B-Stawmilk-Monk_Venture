using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject obstaclePrefab;
    private PlayerController playerController;

    void Start()
    {
        InvokeRepeating("Spawn", 2, 3);
        var go = GameObject.Find("Player");
        playerController = go.GetComponent<PlayerController>();
        //Instantiate(obstaclePrefab, new Vector3(22, 0, 0), obstaclePrefab.transform.rotation);
    }   
    void Spawn()
    {
        if (playerController.isGameOver == false)
        { Instantiate(obstaclePrefab, spawnPoint.position, obstaclePrefab.transform.rotation); }
    }
}
