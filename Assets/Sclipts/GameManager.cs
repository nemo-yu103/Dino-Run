using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

   
    public ScrollBackground background;
    public ScrollBackground background2;
    public ScrollMap map;
    public SpawnItems spawnItems;
    public SpawnEnemy spawnEnemy;
    public SpawnAnimals spawnAnimal;
    public BrockGenerator brockGenerator;
    //public ItemsController itemsController;


    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        // ”wŒi’âŽ~
        background.StopScroll();
        background2.StopScroll();
        map.StopScroll();
        spawnItems.StopSpawn();
        spawnEnemy.StopSpawn(); 
        spawnAnimal.StopSpawn();
        ItemsController.Instance.StopItems();
        brockGenerator.StopSpawn();

        // •K—v‚È‚çŽžŠÔ’âŽ~‚à‚Å‚«‚é
        //Time.timeScale = 0f;
    }
}
