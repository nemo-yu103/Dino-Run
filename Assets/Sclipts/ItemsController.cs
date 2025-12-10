using UnityEngine;

public class ItemsController : MonoBehaviour
{
    float ItemscrollSpeed = 4f;
    private bool isSurvival = true;

    void Start()
    {
        
    }

    void Update()
    {
        if (isSurvival)
        {
            transform.position += Vector3.left * ItemscrollSpeed * Time.deltaTime;
            if (transform.position.x <= -10)
            {
                Destroy(gameObject);
            }
        }
    }

    public void StopItems()
    {
        isSurvival = false;
    }

}
