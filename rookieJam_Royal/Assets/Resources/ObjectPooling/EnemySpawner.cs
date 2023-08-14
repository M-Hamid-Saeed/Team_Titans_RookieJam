using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public int numberOfEnemiesInWave = 5;
    public float timeBetweenSpawns = 1.0f;

    private bool canSpawn = false; // Control whether the spawner can spawn enemies

    private void Update()
    {
        // Check if the spawner can spawn enemies
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemyWave());
            canSpawn = false; // Disable spawning until the next button click
        }
    }

    private IEnumerator SpawnEnemyWave()
    {
        for (int i = 0; i < numberOfEnemiesInWave; i++)
        {
            SpawnEnemyAtSpawnPoint();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void SpawnEnemyAtSpawnPoint()
    {
        ObjectPooler.Instance?.SpawnFromPool("Enemy", spawnPoint.position, Quaternion.identity);
    }

    // Method to enable spawning when the button is clicked
    public void EnableSpawning()
    {
        canSpawn = true;
    }
}
