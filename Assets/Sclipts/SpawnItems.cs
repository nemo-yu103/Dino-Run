using System.Collections;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [Header("スポーン設定")]
    public GameObject coinPrefab;
    public GameObject gemPrefab;
    int itemsPerWave = 3;
    float minSpawnInterval = 1f;
    float maxSpawnInterval = 4f;

    [Header("出現位置設定")]
    float spawnYMin = -3f;
    float spawnYMax = 1.5f;
    float spawnOffsetX = 2f;
    float horizontalSpacing = 1.5f;

    private Camera mainCamera;

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
        while (true)
        {
            CoinSpawn();

            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void CoinSpawn()
    {
        // カメラ右端のワールド座標を取得
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float rightEdge = mainCamera.transform.position.x + camWidth / 2f;

        // Y座標を -3 ～ 1.5 の範囲でランダムに
        float randomY = Random.Range(spawnYMin, spawnYMax);

        for (int i = 0; i < itemsPerWave; i++)
        {

            float xPos = rightEdge + spawnOffsetX + (i * horizontalSpacing);
            Vector3 spawnPos = new Vector3(xPos + spawnOffsetX, randomY, 0f);

            Instantiate(coinPrefab, spawnPos, Quaternion.identity);
        }
    }
}
