using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    //public float dashScrollSpeed = 8f;
    //public float baseScrollSpeed;
    //public float scrollSpeed;
    public float resetPositionX;
    public float startPositionX;

    private bool isScrolling = true;
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

        if (!isScrolling) return;

        float speed = ScrollManager.Instance.GetSpeed() / 2;
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }

    public void StopScroll()
    {
        isScrolling = false;
    }

}
