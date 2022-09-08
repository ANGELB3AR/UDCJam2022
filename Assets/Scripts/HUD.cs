using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemyCountText;

    EnemyStateMachine[] enemies;
    int enemyCount;

    void Awake()
    {
        enemies = FindObjectsOfType<EnemyStateMachine>();
    }

    void Start()
    {
        enemyCount = enemies.Length;
    }

    private void Update()
    {
        DisplayEnemyCount();
    }

    void DisplayEnemyCount()
    {
        enemyCountText.text = "Enemies Remaining: " + enemyCount.ToString();
    }

    public void Recount()
    {
        enemyCount--;
        print($"Recounted and found {enemyCount} enemies remaining");
    }
}
