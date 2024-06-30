using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider _collider)
    {
        if (_collider.TryGetComponent(out ICollectable _collectableObject))
        {
            _collectableObject.Collect();
        }
    }
}
