using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentFloorChunk : Environment, IDespawnable, IFloor
{
    public void Despawn()
    {
        var _floorSpawner = ServiceLocator.Instance.Get<FloorSpawner>();
        _floorSpawner.Despawn(this);
    }
}
