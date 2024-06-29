using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentCoin : Environment, ICollectable
{
    public void Collect()
    {
        Destroy(gameObject);
    }
}
