using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float dashScrollSpeed = 8f;
    public float baseScrollSpeed;
    public float scrollSpeed;
    public float resetPositionX;
    public float startPositionX;

    private bool isScrolling = true;
    public bool isDashing = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (!isScrolling) return;

        scrollSpeed = baseScrollSpeed;

        if (isDashing)
        {
            scrollSpeed += dashScrollSpeed;
        }

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
