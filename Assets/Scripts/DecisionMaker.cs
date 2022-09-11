using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionMaker : MonoBehaviour
{
    Health Player;
    HUD HUD;

    void Awake()
    {
        Player = FindObjectOfType<PlayerStateMachine>().GetComponent<Health>();
        HUD = FindObjectOfType<HUD>();
    }

    private void OnEnable()
    {
        Player.OnDeath += HandlePlayerDeath;
        HUD.OnPlayerWin += HandlePlayerWin;
    }

    private void HandlePlayerDeath()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Lose);
    }

    private void HandlePlayerWin()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Win);
    }
}
