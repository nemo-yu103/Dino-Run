using UnityEngine;

public class ScrollMap : MonoBehaviour
{
    public static ScrollMap Instance;

    [SerializeField] private AudioClip gameBGM;
    

    //public float baseScrollSpeed = 4f;
    //public float dashScrollSpeed = 8f;
    //public float scrollSpeed;
    public float resetPositionX = -17.25f;
    public float startPositionX = 3f;

    public bool isScrolling = true;
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

        float speed = ScrollManager.Instance.GetSpeed();
        transform.Translate(Vector3.left * speed * Time.deltaTime);

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
