using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    private EventBus eventBus;
    private GameState gameState;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        eventBus = ServiceLocator.Instance.Get<EventBus>();
        eventBus.Subscribe<SetGameStateSignal>(OnGameStateChanged);
    }

    private void OnGameStateChanged(SetGameStateSignal _signal)
    {
        switch (_signal.gameStateType)
        {
            case GameStateType.Playing:
                gameState = new PlayingGameState(eventBus);
                break;
            case GameStateType.Defeat:
                gameState = new DefeatGameState(eventBus);
                break;
            default:
                gameState = null;
                Debug.LogError("Game state not implemented!");
                break;
        }

        gameState.Init();
    }
}

public enum GameStateType
{
    Playing,
    Defeat
}