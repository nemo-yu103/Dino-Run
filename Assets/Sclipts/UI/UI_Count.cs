using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class UI_Count : MonoBehaviour
{
    public bool gameNow;
    private float countTime = 4f;

    [SerializeField]
    SpriteResolver CT;

    public SpawnAnimals animal;
    public SpawnEnemy enemy;
    public SpawnItems items;
    public BrockGenerator brock;
    public SpawnFluits fluits;

    void Start()
    {
        
        gameNow = false;
    }

    void Update()
    {
        int label = Mathf.FloorToInt(countTime);

        if (countTime >= 0)
        {
            

            CT.SetCategoryAndLabel("CountNumber", label.ToString());

            countTime = countTime - Time.deltaTime;
            Debug.Log(countTime);
        }
        
        if (label == 0)
        {
            countTime = -1;
            Invoke("GameStart", 0.5f);
        }
         
        
    }

    void GameStart()
    {
        Destroy(gameObject);
        animal.GameStart();
        enemy.GameStart();
        items.GameStart();
        brock.GameStart();
        fluits.GameStart();
    }
}
