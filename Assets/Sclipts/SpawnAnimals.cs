using System.Collections;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    [Header("スポーン設定")]
    public GameObject animalPrefab1;
    public GameObject animalPrefab2;
    float minSpawnInterval = 2f;
    float maxSpawnInterval = 5f;

    [Header("出現位置設定")]
    //float spawnYMin = -3f;
    float spawnOffsetX = 2f;
    float maxSpawnHeight = 3;
    float minSpawnHeight = 0;

    private Camera mainCamera;

    private bool gameNow = false;

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
            AnimalSpawn();

            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void AnimalSpawn()
    {
        bool isbard;
        Vector3 spawnPos;
        GameObject selectedPrefab;

        if (Random.value < 0.5)
        {
            selectedPrefab = animalPrefab1;
            isbard = true;
        }
        else
        {
            selectedPrefab = animalPrefab2;
            isbard = false;
        }

        // カメラ右端のワールド座標を取得
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float rightEdge = mainCamera.transform.position.x + camWidth / 2f;

        float xPos = rightEdge + spawnOffsetX;
        if (!isbard)
        {
            spawnPos = new Vector3(xPos + spawnOffsetX, -3, 0f);
        }
        else
        {
            spawnPos = new Vector3(xPos + spawnOffsetX, Random.Range(minSpawnHeight, maxSpawnHeight), 0f);
        }
        

        Instantiate(selectedPrefab, spawnPos, Quaternion.identity);

    }

    public void StopSpawn()
    {
        gameNow = false;
    }

}
