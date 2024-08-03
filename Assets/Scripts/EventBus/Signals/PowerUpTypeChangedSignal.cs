using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpTypeChangedSignal
{
    public readonly PowerUpType newPowerUpType;
    public readonly GameObject signature;
    
    public PowerUpTypeChangedSignal(PowerUpType _powerUpType, GameObject _signature)
    {
        newPowerUpType = _powerUpType;
        signature = _signature;
    }
}
