using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

   
    public ScrollBackground background; // ”wŒiƒXƒNƒ[ƒ‹
    public ScrollMap map;
    public SpawnItems spawnItems;
    public SpawnEnemy spawnEnemy;
    public ItemsController itemsController;
   

    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        // ”wŒi’â~
        background.StopScroll();
        map.StopScroll();
        spawnItems.StopSpawn();
        spawnEnemy.StopSpawn(); 
        itemsController.StopItems();

        // •K—v‚È‚çŠÔ’â~‚à‚Å‚«‚é
        //Time.timeScale = 0f;
    }
}
