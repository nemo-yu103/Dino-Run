using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;
    public float resetPositionX;
    public float startPositionX;

    private bool isScrolling = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (!isScrolling) return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }

    public void StopScroll()
    {
        isScrolling = false;
    }

}
