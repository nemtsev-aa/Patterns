using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : ObjectsSpawnerBase {
    [SerializeField] private CoinFactory _coinFactory;

    private List<Coin> _coins;

    public override void Reset() {
        StopWork();

        foreach (var iCoin in _coins) {
            Destroy(iCoin.gameObject);
        }

        _coins.Clear();
    }

    public override IEnumerator SpawnObjects() {
        _coins = new List<Coin>();

        foreach (var iTransform in SpawnPoints) {
            Coin coin = _coinFactory.Get(GetRamdomType(), transform);
            coin.transform.position = iTransform.position;
            coin.Destroyed += OnDestroyed;

            _coins.Add(coin);

            yield return new WaitForSeconds(SpawnCooldown);
        }
    }

    private CoinType GetRamdomType() {
        return (CoinType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CoinType)).Length);
    }

    private void OnDestroyed(Coin coin) {
        coin.Destroyed -= OnDestroyed;
        _coins.Remove(coin);
        Destroy(coin.gameObject);
    }
}