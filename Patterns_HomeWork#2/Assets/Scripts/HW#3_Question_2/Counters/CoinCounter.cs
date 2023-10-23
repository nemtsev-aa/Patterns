using System;
using UnityEngine;

public class CoinCounter {
    private int _coins;

    public CoinCounter(int coins) {
        _coins = coins;
    }

    public event Action CoinsCountChanged;

    public void Add(int value) {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _coins += value;
        CoinsCountChanged?.Invoke();
        Debug.Log($"Coins count: {_coins}");
    }
}
