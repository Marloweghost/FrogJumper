using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentPowerUp : Environment, IDespawnable, ICollectable
{
    private System.Random random = new System.Random();
    private PowerUpType currentPowerUpType;

    public void Collect()
    {
        Debug.Log("Collected!");
        ServiceLocator.Instance.Get<PlayerPowerUpController>().ApplyPowerUp(currentPowerUpType);
        Despawn();
    }

    public void Despawn()
    {
        var _powerUpSpawner = ServiceLocator.Instance.Get<PowerUpSpawner>();
        _powerUpSpawner.Despawn(this);
    }

    private void OnEnable()
    {
        currentPowerUpType = GetRandomPowerUpType();  
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
