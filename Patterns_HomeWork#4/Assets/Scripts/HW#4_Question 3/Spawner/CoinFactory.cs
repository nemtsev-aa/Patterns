﻿using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CoinFactory", menuName = "Factory/CoinFactory")]
public class CoinFactory : ScriptableObject {
    [SerializeField] private EmptyCoin _emptyPrefab;
    [SerializeField] private RandomCoin _randomPrefab;
    [SerializeField] private StandartCoin _standartPrefab;

    public Coin Get(CoinType type, Transform parent) {
        switch (type) {
            case CoinType.Empty:
                EmptyCoin eCoin = Instantiate(_emptyPrefab, parent);
                return eCoin;

            case CoinType.Standart:
                StandartCoin sCoin = Instantiate(_standartPrefab, parent);
                return sCoin;

            case CoinType.Random:
                RandomCoin rCoin = Instantiate(_randomPrefab, parent);
                return rCoin;

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
