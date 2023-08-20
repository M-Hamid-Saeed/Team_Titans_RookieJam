using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public static event Action OnLevelComplete;
    public int numberOfEnemiesInWave = 5;
    public static int totalEnemies;
    public float timeBetweenSpawns = 1.0f;

    public bool canSpawn = false; // Control whether the spawner can spawn enemies
    public static int enemyKillCount = 0;


    private void Awake()
    {
        //  if (canSpawn)
        //{

        //  Debug.Log()
        
        StartCoroutine(SpawnEnemyWave());
        //canSpawn = false;// Disable spawning until the next button click
        //}
        totalEnemies = numberOfEnemiesInWave;
        Debug.Log(totalEnemies);

        
    }
    private IEnumerator SpawnEnemyWave()
    {
        Debug.Log(canSpawn);
        yield return new WaitUntil(() => canSpawn);
        enemyKillCount = 0;
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
        if (enemyKillCount == totalEnemies)
        {
            Debug.Log("levelPassed");
            Destroy(AudioManager.instance.Environment1,1f);
            OnLevelComplete?.Invoke();


            return;
        }
        enemyKillCount++;
        Debug.Log(enemyKillCount);
            
    }
   
}
