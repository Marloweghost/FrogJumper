using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSpawner : Spawner<EnvironmentFloorChunk>, IService
{
    private Vector3 prefabSize;
    private GameObject checkingBox;

    public override EnvironmentFloorChunk Spawn()
    {
        return base.Spawn();
    }

    public override void Despawn(EnvironmentFloorChunk _obj)
    {
        base.Despawn(_obj);
    }

    public void InitiateSingleSpawn()
    {
        EnvironmentFloorChunk _floorChunk = Spawn();
        _floorChunk.transform.position = new Vector3(
            checkingBox.transform.position.x,
            checkingBox.transform.position.y,
            checkingBox.transform.position.z + prefabSize.z / 2);
    }

    private void Start()
    {
        prefabSize = prefab.gameObject.GetComponentInChildren<MeshRenderer>().bounds.size;
        checkingBox = CreateCheckingBox(prewarmCount, prefabSize, spawnPoint);

        InitiateFirstSpawn(spawnPoint);
    }

    #region CheckingBox
    private GameObject CreateCheckingBox(int _chunksCount, Vector3 _floorSize, Transform _spawnPoint)
    {
        GameObject _box = new GameObject("CheckingBox");

        _box.AddComponent<FloorCheckingBox>();
        Rigidbody _boxRigidbody = _box.AddComponent<Rigidbody>();
        Collider _boxCollider = _box.AddComponent<BoxCollider>();

        _boxRigidbody.isKinematic = true;
        _boxCollider.isTrigger = true;

        _box.transform.position = CalculateFarthestSpawnPointPosition(_chunksCount, _floorSize, _spawnPoint);
        _box.transform.rotation = Quaternion.identity;
        
        return _box;
    }
    private Vector3 CalculateFarthestSpawnPointPosition(int _chunksCount, Vector3 _floorSize, Transform _spawnPoint)
    {
        return new Vector3(
            _spawnPoint.position.x,
            _spawnPoint.position.y,
            _spawnPoint.position.z + (_chunksCount + 1) * (_floorSize.x + 1));
    }
    #endregion

    private void InitiateFirstSpawn(Transform _spawnPoint)
    {
        for (int index = 0; index < prewarmCount; index++)
        {
            EnvironmentFloorChunk _floorChunk = Spawn();
            _floorChunk.transform.position = new Vector3(
                _spawnPoint.position.x, 
                _spawnPoint.position.y,
                _spawnPoint.position.z + index * prefabSize.z);
        }
    }
}

public class FloorCheckingBox : MonoBehaviour
{
    private FloorSpawner floorSpawner;

    private void Start()
    {
        floorSpawner = ServiceLocator.Instance.Get<FloorSpawner>();  
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.TryGetComponent(out IFloor _floor))
        {
            floorSpawner.InitiateSingleSpawn();
        }
    }
}
