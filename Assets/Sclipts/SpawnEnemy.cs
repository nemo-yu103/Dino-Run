using System.Collections;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("スポーン設定")]
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    float minSpawnInterval = 2f;
    float maxSpawnInterval = 5f;

    [Header("出現位置設定")]
    //float spawnYMin = -3f;
    float spawnOffsetX = 2f;

    private Camera mainCamera;

    public bool gameNow = true;

    void Start()
    {
        mainCamera = Camera.main;
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

        if (Random.value < 0.5)
        {
            selectedPrefab = enemyPrefab1;
        }
        else
        {
            selectedPrefab = enemyPrefab2;
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
