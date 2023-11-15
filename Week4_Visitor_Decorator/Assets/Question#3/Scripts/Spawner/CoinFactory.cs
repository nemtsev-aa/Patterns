using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinFactory", menuName = "Factory/CoinFactory")]
public class CoinFactory : ScriptableObject {
    [SerializeField] private EmptyCoin _emptyPrefab;
    [SerializeField] private RandomCoin _randomPrefab;
    [SerializeField] private StandartCoin _standartPrefab;

    public Coin Get(CoinTypes type, Transform parent) {
        switch (type) {
            case CoinTypes.Empty:
                return Instantiate(_emptyPrefab, parent);

            case CoinTypes.Standart:
                return Instantiate(_standartPrefab, parent);

            case CoinTypes.Random: 
                return Instantiate(_randomPrefab, parent);

            default:
                throw new ArgumentException($"Invalid CoinTypes: {nameof(type)}");
        }
    }
}
