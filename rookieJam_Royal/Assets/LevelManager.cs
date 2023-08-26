using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject environment1;
    public GameObject environment2;
    [SerializeField] EnemySpawner enemySpawner;

    public GameObject level2Manager;

    private void Awake()
    {
        EnemySpawner.enemyKillCount = 0;
        environment1.SetActive(false);
        environment2.SetActive(false);
        EnemySpawner.OnLevelComplete += ReloadSceneWithEnvironmentsSwitched;
        Debug.Log("LEVEL IN AWAKE   " + Level);
        SwitchEnvironments();

        // Activate Level2Manager only when environment2 is active
        if (environment2.activeSelf)
        {

            level2Manager.SetActive(true);

        }
    }

    public void ReloadSceneWithEnvironmentsSwitched()
    {
        SceneManager.LoadScene("Demo");
    }

    public void SwitchEnvironments()
    {
        if (Level == 1)
        {
            Level = 0;
            environment1.SetActive(true);
            environment2.SetActive(false);
        }
        else
        {
            environment1.SetActive(false);
            environment2.SetActive(true);
            Level = 1;
        }
        Debug.Log("LEVEL   " + Level);
    }

    public int Level
    {
        get { return PlayerPrefs.GetInt("Level1"); }
        set { PlayerPrefs.SetInt("Level1", value); }
    }
}
