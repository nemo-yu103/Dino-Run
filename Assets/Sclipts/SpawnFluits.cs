using System.Collections;
using UnityEngine;

public class SpawnFluits : MonoBehaviour
{
    public static SpawnFluits Instance;

    [Header("スポーン設定")]
    public GameObject applePrefab;
    public GameObject bananaPrefab;
    
    float minSpawnInterval = 10f;
    float maxSpawnInterval = 20f;

    [Header("出現位置設定")]
    float spawnYMin = -3f;
    float spawnYMax = 1.5f;
    float spawnOffsetX = 2f;
    

    private Camera mainCamera;
    public bool gameNow = false;

    public void GameStart()
    {
        mainCamera = Camera.main;
        gameNow = true;
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (gameNow == true)
        {
            Debug.Log("ok");
            AppleSpawn();

            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

        }
    }

    void AppleSpawn()
    {
        // カメラ右端のワールド座標を取得
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float rightEdge = mainCamera.transform.position.x + camWidth / 2f;

        // Y座標を -3 ～ 1.5 の範囲でランダムに
        float randomY = Random.Range(spawnYMin, spawnYMax);

        float xPos = rightEdge + spawnOffsetX;
        Vector3 spawnPos = new Vector3(xPos + spawnOffsetX, randomY, 0f);

        Instantiate(applePrefab, spawnPos, Quaternion.identity);
        
    }

    void BananaSpawn()
    {

    }


    public void StopSpawn()
    {
        gameNow = false;
    }


}
