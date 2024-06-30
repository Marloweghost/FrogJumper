using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCoin : Environment, ICollectable
{
    public void Collect()
    {
        var _goldController = ServiceLocator.Instance.Get<CollectedCoinsManager>();
        _goldController.IncrementCoinsCollectedCount();

        Debug.Log($"Coins count: {_goldController.GetCoinsCollectedCount()}");

        Destroy(gameObject);
    }
}
