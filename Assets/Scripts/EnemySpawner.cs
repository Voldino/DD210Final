using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform enemySpawnPoint;
    public GameObject enemyPrefab;
    public float spawnRate = 1f;

    float spawnTimer;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnRate)
        {
            spawnTimer = 0;
            var bullet = Instantiate(enemyPrefab, enemySpawnPoint.position, enemySpawnPoint.rotation);

        }
    }
}

