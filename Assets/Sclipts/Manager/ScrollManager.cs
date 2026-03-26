using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    public static ScrollManager Instance;

    [Header("Šî–{‘¬“x")]
    public float baseScrollSpeed = 4f;

    public bool isDashing = false;
    public float dashScrollSpeed = 8f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }

    public float GetSpeed()
    {
        float speed = baseScrollSpeed;

        if (isDashing)
        {
            speed += dashScrollSpeed;
        }
        return speed;
    }

}
