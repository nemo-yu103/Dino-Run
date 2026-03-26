using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    //public float baseScrollSpeed = 4f;
    //public float dashScrollSpeed = 8f;
    //public float scrollSpeed;
    private bool isSurvival = true;
    //public bool isDashing = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (ScrollManager.Instance == null)
        {
            return;
        }

        if (!isSurvival) return;

        float speed = ScrollManager.Instance.GetSpeed();
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }

    public void EnemyStop()
    {
        isSurvival = false;
        Destroy(gameObject);
    }

}
