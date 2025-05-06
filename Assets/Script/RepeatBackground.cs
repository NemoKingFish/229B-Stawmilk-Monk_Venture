using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPostion;
    private float repeatWidth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPostion = transform.position;
        var b = GetComponent<BoxCollider>();
        repeatWidth = b.size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPostion.x - repeatWidth)
        { transform.position = startPostion; }
    }
}
