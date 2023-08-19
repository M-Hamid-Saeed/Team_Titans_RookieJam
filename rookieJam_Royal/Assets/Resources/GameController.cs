using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject playButton;
    public GameObject darkBackground;
    public GameObject instructionPanel;
    public GameObject PlayAgainPanel;


    public EnemySpawner enemySpawner;

    public float timeDelay = 1.5f;

    private void Awake()
    {
        // Hide instruction panel initially
        instructionPanel.SetActive(false);

        // Show play button and dark background
        playButton.SetActive(true);
        darkBackground.SetActive(true);

    }

    public void PlayGame()
    {
        FindObjectOfType<AudioManager>().Play("click");
        // Hide play button and dark background
        playButton.SetActive(false);
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
}
