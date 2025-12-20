using System.Collections;
using UnityEngine;

public class BrockGenerator : MonoBehaviour
{
    public static BrockGenerator Instance;

    public GameObject brockPrefab1;
    public GameObject brockPrefab2;

    float spawnYMin = -3f;
    float spawnYMax = 1.5f;
    float spawnOffsetX = 2f;
    float horizontalSpacing = 1.5f;

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
        while(gameNow == true)
        {
            BrockSpawn();
            float waitTime = Random.Range(1f, 3f);
            yield return new WaitForSeconds(waitTime);
        }
       
    }

    void BrockSpawn()
    {
        GameObject selectPrefab;

        int brockType = Random.Range(0, 2);
        if (brockType == 0)
        {
            selectPrefab = brockPrefab1;
        }
        else
        {
            selectPrefab = brockPrefab2;
        }

        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;
        float rightEdge = mainCamera.transform.position.x + camWidth / 2f;
        float randomY = Random.Range(spawnYMin, spawnYMax);
    

        float xPos = rightEdge + spawnOffsetX + (2 * horizontalSpacing);
        Vector3 spawnPos = new Vector3(xPos + spawnOffsetX, randomY, 0f);
            
        Instantiate(selectPrefab, spawnPos, Quaternion.identity);
            
        
    }

    public void StopSpawn()
    {
        gameNow = false;
    }

}
