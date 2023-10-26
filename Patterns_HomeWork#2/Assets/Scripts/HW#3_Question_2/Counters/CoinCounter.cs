using System;

public class CoinCounter : IService {
    private int _coins;

    public CoinCounter(int coins) {
        _coins = coins;
    }

    public event Action<int> CoinsCountChanged;

    public void Add(int value) {
        if (value < 0)
            throw new ArgumentOutOfRangeException(nameof(value));

        _coins += value;
        CoinsCountChanged?.Invoke(_coins);
    }

    public void Reset() {
        _coins = 0;
    }
}
