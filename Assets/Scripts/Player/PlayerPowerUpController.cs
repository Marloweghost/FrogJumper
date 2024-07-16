using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPowerUpController : MonoBehaviour, IService
{
    private EventBus eventBus; 

    private void Start()
    {
        eventBus = ServiceLocator.Instance.Get<EventBus>();

        eventBus.Subscribe<PowerUpCollectedSignal>(OnPowerUpCollected);
    }

    private void OnPowerUpCollected(PowerUpCollectedSignal _signal)
    {
        Debug.Log($"Collected {_signal.PowerUpType}!");
    }
}
