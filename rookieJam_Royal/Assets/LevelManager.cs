using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject environment1;
    public GameObject environment2;


    private void Awake()
    {
        environment1.SetActive(false);
        environment2.SetActive(false);
        SwitchEnvironments();
    }

    public void ReloadSceneWithEnvironmentsSwitched()
    {

       
        // SwitchEnvironments();
    }


    public void SwitchEnvironments()
    {
        SceneManager.LoadScene("Demo");
        if (Level==0)
        {
            Level = 1;
            environment1.SetActive(true);
            environment2.SetActive(false);
        }
        else
        {

            environment1.SetActive(false);
            environment2.SetActive(true);
            Level = 0;
        }
    }
    int Level 
    {
        get { return PlayerPrefs.GetInt("Level1"); }
        set { PlayerPrefs.SetInt("Level1", value); }
    }
}
