using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;
    public float resetPositionX;
    public float startPositionX;

    void Start()
    {
        scrollSpeed = 1f;
        resetPositionX = -41f;
        startPositionX = 0.02f;
    }

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}
