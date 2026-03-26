using UnityEngine;

public class ItemsController : MonoBehaviour
{
    public static ItemsController Instance;

    float ItemscrollSpeed = 4f;
    private bool isSurvival = true;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        if (isSurvival)
        {
            if (ScrollManager.Instance == null)
            {
                return;
            }

            

            float speed = ScrollManager.Instance.GetSpeed();
            transform.Translate(Vector3.left * speed * Time.deltaTime);

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
