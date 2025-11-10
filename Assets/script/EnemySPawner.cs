
using System.Collections.Generic;
using UnityEngine;

public class EnemySPawner : MonoBehaviour
{
    public Camera mainCamera;
    Vector2 xSpawnRange;
    Vector2 ySpawnRange;

    [Header("Spawn Settings")]
    public EnemyBase enemyPrefab;
    public float spawnIntervallSeconds = 2;
    public int maxEnemies = 10;


    List<EnemyBase> spawnedEnemis = new List<EnemyBase>();




    float spawnTimer = 0;

    void Start()
    {





        Vector3 leftBottonCameraWorldPosition = mainCamera.ViewportToWorldPoint(Vector2.zero);
        Vector3 rightUpperCameraWorldPosition = mainCamera.ViewportToWorldPoint(Vector2.one);


        xSpawnRange = new Vector2(leftBottonCameraWorldPosition.x, rightUpperCameraWorldPosition.x);
        ySpawnRange = new Vector2(leftBottonCameraWorldPosition.y, rightUpperCameraWorldPosition.y);
    }


    public void EnemyDie(EnemyBase enemy)
    {
        if (spawnedEnemis.Contains(enemy))
        {
            spawnedEnemis.Remove(enemy);
        }
    }
    
    
    void Update()
    {
        if (spawnedEnemis.Count < maxEnemies) 
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnIntervallSeconds)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(xSpawnRange.x, xSpawnRange.y), Random.Range(ySpawnRange.x, ySpawnRange.y), -1);

                EnemyBase newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);

                newEnemy.Initialaze(this);

                spawnedEnemis.Add(newEnemy);

                spawnTimer = 0;
            }

        }
        
        
        
        








    }
}
