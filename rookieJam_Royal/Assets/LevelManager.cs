using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject environment1;
    public GameObject environment2;
    private static int sceneCounter = 0;

    private static LevelManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(environment2);
           DontDestroyOnLoad(environment1);
            
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the scene that was loaded is the target scene
        if (scene.name == "Demo")
        {
            if(sceneCounter == 0)
                SwitchEnvironments1();
            else
                SwitchEnvironments2();
        }
    }

    public void ReloadSceneWithEnvironmentsSwitched()
    {
        SceneManager.LoadScene("Demo");
    }

    public void SwitchEnvironments1()
    {
        sceneCounter++;
        Debug.Log(sceneCounter);

        environment1.SetActive(true);
        environment2.SetActive(false);
    }
    public void SwitchEnvironments2()
    {
       Destroy( environment1);
        environment2.SetActive(true);
    }
}
