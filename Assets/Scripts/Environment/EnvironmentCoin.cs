using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCoin : Environment, ICollectable, IDespawnable
{
    public void Collect()
    {
        var eventBus = ServiceLocator.Instance.Get<EventBus>();
        eventBus.Invoke(new AddCoinsSignal(1));

        Despawn();
    }

    public void Despawn()
    {
        var _coinSpawner = ServiceLocator.Instance.Get<CoinSpawner>();
        _coinSpawner.Despawn(this);
    }
}
