using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public static event Action OnLevelComplete;
    public int numberOfEnemiesInWave;
    public static int totalEnemies;
    public float timeBetweenSpawns = 1.0f;

    public bool canSpawn = false; // Control whether the spawner can spawn enemies
    public static int enemyKillCount = 0;

    private void Awake()
    {
        StartCoroutine(SpawnEnemyWave());
        totalEnemies = numberOfEnemiesInWave;
    }

    private IEnumerator SpawnEnemyWave()
    {
        yield return new WaitUntil(() => canSpawn);
        Debug.Log("SPAWNING ENEMY WAVE");
        for (int i = 0; i < numberOfEnemiesInWave; i++)
        {
            SpawnEnemyAtRandomPoint();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    private void SpawnEnemyAtRandomPoint()
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
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

        // Check if all enemies have been killed
        if (enemyKillCount > totalEnemies)
        {
            Debug.Log("levelPassed");
            OnLevelComplete?.Invoke();
        }
    }
}
