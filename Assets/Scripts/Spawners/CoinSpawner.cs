using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : Spawner<EnvironmentCoin>, IService
{
    [Header("Specific settings")]
    [SerializeField] private float spawnCooldown;

    private Timer timer;
    private LaneManager laneManager;
    private System.Random random = new System.Random();

    public override EnvironmentCoin Spawn()
    {
        return base.Spawn();
    }

    public override void Despawn(EnvironmentCoin environmentCoin)
    {
        base.Despawn(environmentCoin);
    }

    private void Start()
    {
        laneManager = ServiceLocator.Instance.Get<LaneManager>();
        StartSpawn();
    }

    private void StartSpawn()
    {
        timer = Timer.Register(spawnCooldown, SpawnCoin, isLooped: true);
    }

    private void StopSpawn()
    {
        Timer.Cancel(timer);
    }

    private void SpawnCoin()
    {
        EnvironmentCoin _coin = Spawn();
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
