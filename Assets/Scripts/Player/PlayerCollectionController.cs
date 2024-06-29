using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out ICollectable collectableObject))
        {
            collectableObject.Collect();
        }
    }
}
