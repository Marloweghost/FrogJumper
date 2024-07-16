using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCoinsSignal
{
    public readonly int CoinAmount;

    public AddCoinsSignal(int _coinAmount)
    {
        CoinAmount = _coinAmount;
    }
}
