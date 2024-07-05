using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorLoader_Main : MonoBehaviour
{
    [SerializeField] private CollectedCoinsManager collectedCoinsManager;
    [SerializeField] private CoinSpawner coinSpawner;
    [SerializeField] private LaneManager laneManager;

    private void Awake()
    {
        ServiceLocator.Initialize();

        ServiceLocator.Instance.Register(collectedCoinsManager);
        ServiceLocator.Instance.Register(coinSpawner);
        ServiceLocator.Instance.Register(laneManager);
    }
}
