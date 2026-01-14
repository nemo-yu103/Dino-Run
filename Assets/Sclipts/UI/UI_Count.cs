using Unity.Mathematics;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class UI_Count : MonoBehaviour
{
    public bool gameNow;
    public bool isCountDown;
    private float countTime = 4f;

    [SerializeField]
    GameObject go;
    SpriteResolver CT;
    SpriteRenderer Num;

    public SpawnAnimals animal;
    public SpawnEnemy enemy;
    public SpawnItems items;
    public BrockGenerator brock;
    public SpawnFluits fluits;

    void Start()
    {
        gameNow = false;
        isCountDown = false;
        CT = go.GetComponent<SpriteResolver>();
        Num = go.GetComponent<SpriteRenderer>();
        Num.enabled = false;
    }

    void Update()
    {         
        if (isCountDown) CountDown();
    }

    public void StartCountDown()
    {
        Num.enabled = true;
        isCountDown = true;
    }

    void CountDown()
    {
        int label = Mathf.FloorToInt(countTime);

        if (countTime >= 0)
        {
            CT.SetCategoryAndLabel("CountNumber", label.ToString());

            countTime = countTime - Time.deltaTime;
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
