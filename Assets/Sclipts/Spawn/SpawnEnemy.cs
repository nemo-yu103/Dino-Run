using System.Collections;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] ChangeMapSkin changeMap;

    [Header("スポーン設定")]
    public GameObject[] enemyPrefab1 = new GameObject[3];
    public GameObject[] enemyPrefab2 = new GameObject[3];
    float minSpawnInterval = 2f;
    float maxSpawnInterval = 5f;

    [Header("出現位置設定")]
    //float spawnYMin = -3f;
    float spawnOffsetX = 2f;

    private Camera mainCamera;

    private bool gameNow = false;
    private int animNo;

    public void GameStart()
    {
        mainCamera = Camera.main;
        gameNow = true;
        StartCoroutine(SpawnLoop());
    }

    void Update()
    {

    }

    IEnumerator SpawnLoop()
    {
        while (gameNow==true)
        {
            EnemySpawn();

            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void EnemySpawn()
    {
        GameObject selectedPrefab;

        animNo = changeMap.skinNo;

        if (Random.value < 0.5)
        {
            selectedPrefab = enemyPrefab1[animNo];
        }
        else
        {
            selectedPrefab = enemyPrefab2[animNo];
        }

        // カメラ右端のワールド座標を取得
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float rightEdge = mainCamera.transform.position.x + camWidth / 2f;

        float xPos = rightEdge + spawnOffsetX;
        Vector3 spawnPos = new Vector3(xPos + spawnOffsetX, -3, 0f);

        Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        
    }

    public void StopSpawn()
    {
        gameNow = false;
    }

}
