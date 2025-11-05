using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    public float scrollSpeed = 5f;
    public float resetPositionX = -20f;
    public float startPositionX = 20f;

    void Start()
    {
        
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
