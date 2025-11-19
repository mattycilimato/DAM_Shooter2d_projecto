using System.Collections.Generic;
using UnityEngine;

public class WindowsSpawner : EnemySpawner
{
    [Header("Spawn Settings")]
    public float spawnIntervallSeconds = 2;
    public int maxEnemies = 10;
    public List<Vector3> spawnPosition = new List<Vector3>();


    float spawnTimer = 0;








    void Update()
    {
        if (spawnedEnemis.Count < maxEnemies)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnIntervallSeconds)
            {

                int randomIndex = Random.Range(0, spawnPosition.Count);





                SpawnEnemy(spawnPosition[randomIndex]);

                spawnTimer = 0;
            }

        }












    }
}
