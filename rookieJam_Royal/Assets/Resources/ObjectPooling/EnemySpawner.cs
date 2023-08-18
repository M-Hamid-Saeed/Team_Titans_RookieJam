using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;

    public int numberOfEnemiesInWave = 5;
    private static int totalEnemies;
    public float timeBetweenSpawns = 1.0f;

    private bool canSpawn = false; // Control whether the spawner can spawn enemies
    public static int enemyKillCount = 0;
    private void Update()
    {
        // Check if the spawner can spawn enemies
        if (canSpawn)
        {
            StartCoroutine(SpawnEnemyWave());
            canSpawn = false; // Disable spawning until the next button click
        }
        totalEnemies = numberOfEnemiesInWave;
    }

    private IEnumerator SpawnEnemyWave()
    {
        for (int i = 0; i < numberOfEnemiesInWave; i++)
        {
            SpawnEnemyAtRandomPoint();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void SpawnEnemyAtRandomPoint()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Vector3 randomSpawnPoint = spawnPoints[randomIndex].position;

        ObjectPooler.Instance.SpawnFromPool("Enemy", randomSpawnPoint, Quaternion.identity);
    }

    // Method to enable spawning when the button is clicked
    public void EnableSpawning()
    {
        canSpawn = true;
    }
 
    public static void AddKillCount()
    {

        enemyKillCount++;
        Debug.Log(enemyKillCount);
        if (enemyKillCount == totalEnemies)
        {
            Debug.Log("LEVEL PASSED");
            return;
        }
        
    }
}
