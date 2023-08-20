using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public int numberOfEnemiesInWave;

    // Property to set and get the number of enemies in the wave
   

    private void Awake()
    {
            EnemySpawner.OnLevelComplete += OnLevelComplete;
    }

    private void OnLevelComplete()
    {
        StartCoroutine(waitForSceneLoad());
        
        
    }
    private  IEnumerator waitForSceneLoad()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // Update the number of enemies in the wave
        AudioManager.instance.enemySpawner.numberOfEnemiesInWave = numberOfEnemiesInWave;

        // Save any necessary data here if needed



        Instantiate(AudioManager.instance.Environment2.gameObject, this.transform.position, Quaternion.identity);
        //Destroy(AudioManager.instance.Environment1);

    }
}
