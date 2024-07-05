using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour, IService
{
    [SerializeField] private EnvironmentCoin coinPrefab;
    [SerializeField] private int prewarmCoinCount;
    [SerializeField] private float spawnCooldown;
    [SerializeField] private Transform spawnPoint;

    private CustomPool<EnvironmentCoin> coinPool;
    private Timer timer;
    private LaneManager laneManager;
    private System.Random random = new System.Random();

    public void Despawn(EnvironmentCoin environmentCoin)
    {
        coinPool.Release(environmentCoin);
    }

    private void Start()
    {
        laneManager = ServiceLocator.Instance.Get<LaneManager>();

        coinPool = new CustomPool<EnvironmentCoin>(coinPrefab, prewarmCoinCount);
        StartSpawn();
    }

    private void StartSpawn()
    {
        timer = Timer.Register(spawnCooldown, Spawn, isLooped: true);
    }

    private void Spawn()
    {
        EnvironmentCoin _coin = coinPool.Get();
        _coin.transform.position = GenerateRandomLanePosition();
    }

    private Vector3 GenerateRandomLanePosition()
    {
        return new Vector3(
            spawnPoint.position.x + random.Next(-1,2) * laneManager.GetDistance(), 
            spawnPoint.position.y, 
            spawnPoint.position.z);
    }
}
