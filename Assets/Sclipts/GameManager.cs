using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

   
    public ScrollBackground background; // ”wŒiƒXƒNƒ[ƒ‹
    public ScrollMap map;
   

    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        // ”wŒi’â~
        background.StopScroll();
        map.StopScroll();

        // •K—v‚È‚çŠÔ’â~‚à‚Å‚«‚é
        //Time.timeScale = 0f;
    }
}
