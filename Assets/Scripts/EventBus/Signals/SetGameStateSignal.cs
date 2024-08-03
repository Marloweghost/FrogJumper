using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameStateSignal
{
    public readonly GameStateType gameStateType;

    public SetGameStateSignal(GameStateType _gameStateType)
    {
        gameStateType = _gameStateType;
    }
}
