using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Manager : MonoBehaviour
{
    public GameObject ui1;
    public GameObject ui2;
    public GameObject darkBackground;
    public GameObject level2Panel;

    public EnemySpawner enemySpawner;
    public pathCreator pathCreator;
    public InteractableButton interactableButton;

    void Awake()
    {
        Debug.Log("Level 2 Manager is Runnig");
        ui1.SetActive(false);
        ui2.SetActive(true);

        darkBackground.SetActive(true);
        level2Panel.SetActive(true);


        enemySpawner.numberOfEnemiesInWave = 50;
        pathCreator.maxSoldierCount = 30;
        interactableButton.maxInteractions = 7;


    }

    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("click");
        darkBackground.SetActive(false);
        level2Panel.SetActive(false);

        enemySpawner.EnableSpawning();
    }
}
