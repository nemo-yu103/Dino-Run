using UnityEngine;

public class FluitsController : ScrollMap
{
    public static FluitsController Instance;

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

    public void GetFluits()
    {
        scrollSpeed += 1f;
    }
    
}
