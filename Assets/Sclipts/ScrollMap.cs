using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    public float scrollSpeed;
    public float resetPositionX;
    public float startPositionX;

    void Start()
    {
        scrollSpeed = 4f;
        resetPositionX = -17.25f;
        startPositionX = 3f;
    }

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX,transform.position.y,transform.position.z);
        }
    }
}
