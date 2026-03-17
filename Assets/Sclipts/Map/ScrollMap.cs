using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    public static ScrollMap Instance;

    [SerializeField] private AudioClip gameBGM;

    public float baseScrollSpeed = 4f;
    public float dashScrollSpeed = 8f;
    public float scrollSpeed;
    public float resetPositionX;
    public float startPositionX;

    public bool isScrolling = true;
    public bool isDashing = false;

    void Start()
    {
        resetPositionX = -17.25f;
        startPositionX = 3f;
    }

    void Update()
    {
        if (!isScrolling) return;

        scrollSpeed = baseScrollSpeed;

        if (isDashing)
        {
            scrollSpeed += dashScrollSpeed;
        }

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
        if (transform.position.x <= resetPositionX)
        {
            transform.position = new Vector3(startPositionX,transform.position.y,transform.position.z);
        }
    }

    public void PlayBGM()
    {
        AudioManager.Instance.PlayBGM(gameBGM,0.3f);
    }

    public void StopScroll()
    {
        isScrolling = false;
        AudioManager.Instance.StopBGM();
    }

}
