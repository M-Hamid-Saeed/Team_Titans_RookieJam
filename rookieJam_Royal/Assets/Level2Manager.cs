using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace for working with UI elements

public class Level2Manager : MonoBehaviour
{
    public EnemySpawner enemySpawner; // Reference to the EnemySpawner script
    public Button spawnButton; // Reference to the spawn button

    public void OnSpawnButtonClicked()
    {
        // Call the EnableSpawning method of the EnemySpawner script
        enemySpawner.EnableSpawning();

        // Disable the spawn button
        spawnButton.interactable = false;
        spawnButton.gameObject.SetActive(false);
    }
}
