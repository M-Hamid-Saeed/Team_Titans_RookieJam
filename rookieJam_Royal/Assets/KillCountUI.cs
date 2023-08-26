using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillCountUI : MonoBehaviour
{
    public TextMeshProUGUI killCountText;
   // public EnemySpawner enemySpawner; 

    private void Update()
    {
        UpdateKillCountUI();
    }

    private void UpdateKillCountUI()
    {
        killCountText.text = EnemySpawner.enemyKillCount + "/" + EnemySpawner.totalEnemies;
    }
}
