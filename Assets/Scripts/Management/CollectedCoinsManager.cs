using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedCoinsManager : IService
{
    private int coinsCollected = 0;
    private int CoinsCollected
    {
        get => coinsCollected;
        set
        {
            if (value < 0)
            {
                coinsCollected = 0;
            }
            else
            {
                coinsCollected = value;
            }
        }
    }

    public int GetCoinsCollectedCount()
    {
        return CoinsCollected;
    }

    public void IncrementCoinsCollectedCount()
    {
        CoinsCollected++;
    }
}
