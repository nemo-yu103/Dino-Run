using UnityEngine;

public class BrockController : MonoBehaviour
{
    public float scrollSpeed;

    private bool isScrolling = true;

    void Start()
    {
        scrollSpeed = 4f;
    }

    void Update()
    {
        if (!isScrolling) return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if(transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
    }

    public void StopScroll()
    {
        isScrolling = false;
    }
}
