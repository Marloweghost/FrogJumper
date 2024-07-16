using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoinsManager : MonoBehaviour, IService
{
    [SerializeField] private int coinsCollected = 0;

    private EventBus eventBus;

    private void Start()
    {
        eventBus = ServiceLocator.Instance.Get<EventBus>();

        eventBus.Subscribe<AddCoinsSignal>(AddCoinsCollectedCount);
    }

    private int CoinsCollected
    {
        get => coinsCollected;
        set
        {
            if (value < 0)
            {
                coinsCollected = 0;
            }
            else
            {
                coinsCollected = value;
            }
        }
    }

    public int GetCoinsCollectedCount()
    {
        return CoinsCollected;
    }

    public void AddCoinsCollectedCount(AddCoinsSignal _signal)
    {
        CoinsCollected += _signal.CoinAmount;
        Debug.Log($"Coins count: {GetCoinsCollectedCount()}");
    }
}
