using System;
using UnityEngine;

public abstract class Coin : MonoBehaviour {
    public event Action<Coin> Destroyed;
    
    private void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out ICoinPicker coinPicker)) {
            AddCoins(coinPicker);
            Destroyed?.Invoke(this);
        }
    }

    public abstract void AddCoins(ICoinPicker coinPicker);
}

