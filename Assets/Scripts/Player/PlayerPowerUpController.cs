using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpController : MonoBehaviour, IService
{
    private EventBus eventBus;

    private Dictionary<PowerUpType, Timer> buffTimers = new Dictionary<PowerUpType, Timer>();

    [Header("SpeedSlower")]
    [SerializeField] private float slowAmount = 1f;
    [SerializeField] private float slowDuration = 5f;
    [Header("CoinMagnet")]
    [SerializeField] private float pullSpeed = 1f;

    private void Start()
    {
        eventBus = ServiceLocator.Instance.Get<EventBus>();

        eventBus.Subscribe<PowerUpCollectedSignal>(OnPowerUpCollected);
    }

    private void OnPowerUpCollected(PowerUpCollectedSignal _signal)
    {
        Debug.Log($"Collected {_signal.PowerUpType}!");

        switch (_signal.PowerUpType)
        {
            case PowerUpType.SpeedSlower:
                ApplySpeedSlower();
                break;
            case PowerUpType.CoinMagnet:

                break;
            default:
                Debug.Log($"{_signal.PowerUpType} behaviour is not defined!");
                break;
        }
    }

    #region SpeedSlower
    private void ApplySpeedSlower()
    {
        eventBus.Invoke(new SlowSpeedSignal(slowAmount));
        LaunchBuffTimer(PowerUpType.SpeedSlower, slowDuration, OnSpeedSlowerExpired);
    }

    private void OnSpeedSlowerExpired()
    {
        eventBus.Invoke(new AddSpeedSignal(slowAmount));
        StopBuffTimer(PowerUpType.SpeedSlower);
    }
    #endregion

    private void ApplyCoinMagnet()
    {

    }

    #region BuffTimerCommands
    private void LaunchBuffTimer(PowerUpType _key, float _duration, Action _onExpired)
    {
        if (!buffTimers.ContainsKey(_key))
        {
            buffTimers.Add(_key, Timer.Register(_duration, _onExpired));
        }
        else
        {
            Debug.LogWarning("Buff timer by key already exists!");
        }
    }

    private void StopBuffTimer(PowerUpType _key)
    {
        if (buffTimers.ContainsKey(_key))
        {
            buffTimers.Remove(_key);
        }
    }
    #endregion
}
