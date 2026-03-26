using UnityEngine;

public class BrockController : MonoBehaviour
{
    public static BrockController Instance;

    private bool isScrolling = true;
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

        if (transform.position.x < -11f)
        {
            Destroy(gameObject);
        }
    }

    public void StopScroll()
    {
        isScrolling = false;
    }

    //public void GetFluits()
    //{
    //    scrollSpeed += 1f;
    //}
}
