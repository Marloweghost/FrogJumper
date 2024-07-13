using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour
{
    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.TryGetComponent(out IDespawnable _despawnableObject))
        {
            _despawnableObject.Despawn();
        }
    }
}
