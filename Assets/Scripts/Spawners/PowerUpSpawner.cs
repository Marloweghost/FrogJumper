using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpSpawner : Spawner<EnvironmentPowerUp>, IService
{
    [Header("Specific settings")]
    [SerializeField] private float spawnCooldown;

    private Timer timer;
    private LaneManager laneManager;
    private System.Random random = new System.Random();

    public override EnvironmentPowerUp Spawn()
    {
        return base.Spawn();
    }

    public override void Despawn(EnvironmentPowerUp _obj)
    {
        base.Despawn(_obj);
    }

    private void Start()
    {
        laneManager = ServiceLocator.Instance.Get<LaneManager>();
        StartSpawn();
    }

    private void StartSpawn()
    {
        timer = Timer.Register(spawnCooldown, SpawnPowerUp, isLooped: true);
    }

    private void SpawnPowerUp()
    {
        EnvironmentPowerUp _powerUp = Spawn();
        _powerUp.transform.position = GenerateRandomLanePosition();
    }

    private Vector3 GenerateRandomLanePosition()
    {
        return new Vector3(
            spawnPoint.position.x + random.Next(-1, 2) * laneManager.GetDistance(),
            spawnPoint.position.y,
            spawnPoint.position.z);
    }

}
