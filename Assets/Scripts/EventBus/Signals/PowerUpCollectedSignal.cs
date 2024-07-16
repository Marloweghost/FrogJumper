using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpCollectedSignal
{
    public readonly PowerUpType PowerUpType;

    public PowerUpCollectedSignal(PowerUpType _powerUpType)
    {
        PowerUpType = _powerUpType;
    }
}
