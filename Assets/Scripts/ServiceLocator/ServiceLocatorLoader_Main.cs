using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorLoader_Main : MonoBehaviour
{
    [SerializeField] private CollectedCoinsManager collectedCoinsManager;
    [SerializeField] private CoinSpawner coinSpawner;
    [SerializeField] private LaneManager laneManager;
    [SerializeField] private FloorSpawner floorSpawner;
    [SerializeField] private PowerUpSpawner powerUpSpawner;
    [SerializeField] private PlayerPowerUpController playerPowerUpController;

    private void Awake()
    {
        ServiceLocator.Initialize();

        ServiceLocator.Instance.Register(collectedCoinsManager);
        ServiceLocator.Instance.Register(coinSpawner);
        ServiceLocator.Instance.Register(laneManager);
        ServiceLocator.Instance.Register(floorSpawner);
        ServiceLocator.Instance.Register(powerUpSpawner);
        ServiceLocator.Instance.Register(playerPowerUpController);
    }
}
