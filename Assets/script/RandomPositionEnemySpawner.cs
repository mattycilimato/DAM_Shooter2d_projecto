
using System.Collections.Generic;
using UnityEngine;

public class RandomPositionEnemySpawner : EnemySpawner
{
    public Camera mainCamera;
    Vector2 xSpawnRange;
    Vector2 ySpawnRange;

    
    public float spawnIntervallSeconds = 2;
    public int maxEnemies = 10;


    




    float spawnTimer = 0;

    void Start()
    {





        Vector3 leftBottonCameraWorldPosition = mainCamera.ViewportToWorldPoint(Vector2.zero);
        Vector3 rightUpperCameraWorldPosition = mainCamera.ViewportToWorldPoint(Vector2.one);


        xSpawnRange = new Vector2(leftBottonCameraWorldPosition.x, rightUpperCameraWorldPosition.x);
        ySpawnRange = new Vector2(leftBottonCameraWorldPosition.y, rightUpperCameraWorldPosition.y);
    }


   
    
    void Update()
    {
        if (spawnedEnemis.Count < maxEnemies) 
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnIntervallSeconds)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y), Random.Range(ySpawnRange.x, ySpawnRange.y), -1);

                SpawnEnemy(spawnPosition);

                spawnTimer = 0;
            }

        }
        
        
        
        








    }
}
