using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            // Spawn an enemy when the screen is touched
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                SpawnEnemyAtSpawnPoint();
            }
        }
    }

    private void SpawnEnemyAtSpawnPoint()
    {
        ObjectPooler.Instance.SpawnFromPool("Enemy", spawnPoint.position, Quaternion.identity);
    }
}
