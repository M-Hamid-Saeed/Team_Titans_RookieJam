using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject StartPanel;
    //public GameObject playButton;
    public GameObject darkBackground;
    public GameObject instructionPanel;
    public GameObject PlayAgainPanel;
    public GameObject NextLevelPanel;

    public EnemySpawner enemySpawner;

    public float timeDelay = 1.0f;

    private void Awake()
    {
        EnemySpawner.OnLevelComplete += OnLevelCompleteHandler;

        // Hide instruction panel initially
        instructionPanel.SetActive(false);
        
        darkBackground.SetActive(true);
        StartPanel.SetActive(true);
    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("click");
        // Hide play button and dark background
        StartPanel.SetActive(false);
        darkBackground.SetActive(false);

        // Show instruction panel after a delay
        StartCoroutine(ShowInstructionsWithDelay());
    }

    private IEnumerator ShowInstructionsWithDelay()
    {
        yield return new WaitForSeconds(timeDelay);
        darkBackground.SetActive(true);
        instructionPanel.SetActive(true);
    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("click");
        darkBackground.SetActive(false);
        instructionPanel.SetActive(false);

        enemySpawner.EnableSpawning();
    }

    public void PlayAgain()
    {
        darkBackground.SetActive(true);
        PlayAgainPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Demo");
    }

    public void OnLevelCompleteHandler()
    {
        FindObjectOfType<AudioManager>().Play("click");
        darkBackground.SetActive(true);
        NextLevelPanel.SetActive(true);
    }
}
