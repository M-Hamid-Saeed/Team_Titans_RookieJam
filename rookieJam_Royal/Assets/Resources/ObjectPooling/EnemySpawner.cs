using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public int numberOfEnemiesInWave = 5;
    public float timeBetweenSpawns = 1.0f;

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Spawn a wave of enemies when the screen is touched
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                StartCoroutine(SpawnEnemyWave());
            }
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
}
