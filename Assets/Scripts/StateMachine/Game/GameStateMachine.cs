using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : StateMachine
{
    [field: SerializeField] public LevelManager LevelManager { get; private set; }
}
