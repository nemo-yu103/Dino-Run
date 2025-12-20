using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static EnemyController Instance;

    float ItemscrollSpeed;
    private bool isSurvival = true;

    void Start()
    {
        ItemscrollSpeed = 4f;
    }

    void Update()
    {
        if (!isSurvival) return;

        transform.position += Vector3.left * ItemscrollSpeed * Time.deltaTime;
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

    public void GetFluits()
    {
        ItemscrollSpeed += 1f;
    }

}
