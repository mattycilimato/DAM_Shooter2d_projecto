using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public EnemyBase enemyPrefab;

    protected List<EnemyBase> spawnedEnemis = new List<EnemyBase>();

    public void EnemyDie(EnemyBase enemy)
    {
        if (spawnedEnemis.Contains(enemy))
        {
            spawnedEnemis.Remove(enemy);
        }
    }

    public void SpawnEnemy(Vector3 spawnPosition)
    {
        EnemyBase newEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity, transform);

        newEnemy.Initialaze(this);

        spawnedEnemis.Add(newEnemy);
    }


}
