using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    public static ScrollMap Instance;


    public float scrollSpeed;
    public float resetPositionX;
    public float startPositionX;

    public bool isScrolling = true;

    void Start()
    {
        scrollSpeed = 4f;
        resetPositionX = -17.25f;
        startPositionX = 3f;
    }

    void Update()
    {
        if (!isScrolling) return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX,transform.position.y,transform.position.z);
        }
    }

    public void StopScroll()
    {
        isScrolling = false;
    }

    public void GetFluits()
    {
        Debug.Log("ok");
        scrollSpeed += 1f;
    }

}
