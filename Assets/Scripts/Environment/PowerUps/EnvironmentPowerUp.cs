using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnvironmentPowerUp : Environment, IDespawnable, ICollectable
{
    private System.Random random = new System.Random();
    [SerializeField] private PowerUpType powerUpType;

    public void Collect()
    {
        var _eventBus = ServiceLocator.Instance.Get<EventBus>();
        _eventBus.Invoke(new PowerUpCollectedSignal(powerUpType));

        Despawn();
    }

    public void Despawn()
    {
        var _powerUpSpawner = ServiceLocator.Instance.Get<PowerUpSpawner>();
        _powerUpSpawner.Despawn(this);
    }

    private void OnEnable()
    {
        powerUpType = GetRandomPowerUpType();
    }

    private PowerUpType GetRandomPowerUpType()
    {
        return (PowerUpType)random.Next(0, Enum.GetNames(typeof(PowerUpType)).Length);
    }
}

public enum PowerUpType
{
    SpeedSlower,
    CoinMagnet,
}
