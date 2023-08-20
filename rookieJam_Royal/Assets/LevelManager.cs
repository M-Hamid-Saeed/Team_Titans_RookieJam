using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject environment1;
    public GameObject environment2;

    private static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ReloadSceneWithEnvironmentsSwitched()
    {
        
        SceneManager.LoadScene("Demo");
        SwitchEnvironments();
    }


    public void SwitchEnvironments()
    {
        environment1.SetActive(false);
        environment2.SetActive(false);
    }
}
