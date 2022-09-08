using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HUD : MonoBehaviour
{
    public event Action OnPlayerWin;

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
        DisplayEnemyCount();

        if (enemyCount == 0)
        {
            OnPlayerWin?.Invoke();
        }
    }
}
