using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceLocatorLoader_Main : MonoBehaviour
{
    private void Awake()
    {
        ServiceLocator.Initialize();

        CollectedCoinsManager _collectedCoinManager = new CollectedCoinsManager();
        ServiceLocator.Instance.Register(_collectedCoinManager);
    }
}
