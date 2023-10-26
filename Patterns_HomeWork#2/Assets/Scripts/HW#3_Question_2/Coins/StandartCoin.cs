using System;
using UnityEngine;

public class StandartCoin : Coin {
    [SerializeField, Range(0, 50)] private int _value;
    
    public override void AddCoins(ICoinPicker coinPicker) => coinPicker.PickCoin(_value);
}
