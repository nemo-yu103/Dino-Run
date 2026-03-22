using UnityEngine;

public class FluitsController : ScrollMap
{
    
    void Start()
    {
        scrollSpeed = 4f;
    }

    void Update()
    {
        if (!isScrolling) return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

    }
}
