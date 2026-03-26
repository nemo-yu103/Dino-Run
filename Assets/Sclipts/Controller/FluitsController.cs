using UnityEngine;

public class FluitsController : ScrollMap
{
    

    void Start()
    {
         
    }

    void Update()
    {
        if (ScrollManager.Instance == null)
        {
            return;
        }

        if (!isScrolling) return;

        float speed = ScrollManager.Instance.GetSpeed();
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }

    }
}
