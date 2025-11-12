using UnityEngine;

public class ItemsController : MonoBehaviour
{
    float ItemscrollSpeed = 4f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position += Vector3.left * ItemscrollSpeed * Time.deltaTime;
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

   


}
