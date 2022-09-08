using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemyCountText;

    int enemyCount;

    void Start()
    {
        CountEnemies();
    }

    void Update()
    {
        CountEnemies();
        DisplayEnemyCount();
    }

    void CountEnemies()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    void DisplayEnemyCount()
    {
        enemyCountText.text = "Enemies Remaining: " + enemyCount.ToString();
    }
}
