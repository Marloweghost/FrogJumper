using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCoin : Environment, ICollectable, IDespawnable
{
    public void Collect()
    {
        var _goldController = ServiceLocator.Instance.Get<CollectedCoinsManager>();
        _goldController.IncrementCoinsCollectedCount();

        Debug.Log($"Coins count: {_goldController.GetCoinsCollectedCount()}");

        var _coinSpawner = ServiceLocator.Instance.Get<CoinSpawner>();
        _coinSpawner.Despawn(this);
    }

    public void Despawn()
    {
        var _coinSpawner = ServiceLocator.Instance.Get<CoinSpawner>();
        _coinSpawner.Despawn(this);
    }
}
