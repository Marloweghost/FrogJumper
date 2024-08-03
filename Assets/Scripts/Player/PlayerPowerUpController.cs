using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpController : MonoBehaviour, IService
{
    private EventBus eventBus;

    private Dictionary<PowerUpType, Timer> buffTimers = new Dictionary<PowerUpType, Timer>();

    [Header("SpeedSlower")]
    [SerializeField] private float slowDuration = 5f;
    [SerializeField] private float slowAmount = 5f;

    [Header("CoinMagnet")]
    [SerializeField] private GameObject coinMagnetPrefab;
    [SerializeField] private float pullDuration = 5f;
    [SerializeField] private float pullForce = 5f;
    [SerializeField] private float pullRadius = 15f;
    private GameObject coinMagnetInstance;

    private void Start()
    {
        eventBus = ServiceLocator.Instance.Get<EventBus>();

        eventBus.Subscribe<PowerUpCollectedSignal>(OnPowerUpCollected);
    }

    // TODO: Заменить методы на Factory
    private void OnPowerUpCollected(PowerUpCollectedSignal _signal)
    {
        Debug.Log($"Collected {_signal.PowerUpType}!");

        switch (_signal.PowerUpType)
        {
            case PowerUpType.SpeedSlower:
                ApplySpeedSlower();
                break;
            case PowerUpType.CoinMagnet:
                ApplyCoinMagnet();
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
        LaunchOrUpdateBuffTimer(PowerUpType.SpeedSlower, slowDuration, OnSpeedSlowerExpired);
    }

    private void OnSpeedSlowerExpired()
    {
        eventBus.Invoke(new AddSpeedSignal(slowAmount));
        StopBuffTimer(PowerUpType.SpeedSlower);
    }
    #endregion

    #region CoinMagnet
    private void ApplyCoinMagnet()
    {
        if (coinMagnetInstance != null)
        {
            Destroy(coinMagnetInstance);
        }

        coinMagnetInstance = Instantiate(coinMagnetPrefab, transform.position, Quaternion.identity, transform);
        coinMagnetInstance.GetComponent<CoinMagnet>().Initialize(pullForce, pullRadius);
        LaunchOrUpdateBuffTimer(PowerUpType.CoinMagnet, pullDuration, OnCoinMagnetExpired);
    }

    private void OnCoinMagnetExpired()
    {
        Destroy(coinMagnetInstance);
        StopBuffTimer(PowerUpType.CoinMagnet);
    }
    #endregion

    #region BuffTimerCommands
    private void LaunchOrUpdateBuffTimer(PowerUpType _key, float _duration, Action _onExpired)
    {
        if (!buffTimers.ContainsKey(_key))
        {
            buffTimers.Add(_key, Timer.Register(_duration, _onExpired));
        }
        else
        {
            buffTimers.GetValueOrDefault(_key).Cancel();
            buffTimers.Remove(_key);
            buffTimers.Add(_key, Timer.Register(_duration, _onExpired));
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
