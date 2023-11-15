using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawner : ObjectsSpawnerBase {
    public event Action StartCreated;
    public event Action StopCreated;

    [SerializeField] private CoinFactory _coinFactory;
    private List<Coin> _coins;

    public override void Reset() {
        StopWork();

        if (_coins != null)
            ClearCoinsList();
    }

    protected override IEnumerator SpawnObjects() {
        StartCreated?.Invoke();

        _coins = new List<Coin>();

        for (int i = 0; i < SpawnPoints.Count; i++) {
            Coin coin = _coinFactory.Get(GetRamdomType(), transform);
            MoveCoinToFreeSpawnPoint(coin);
            coin.Destroyed += OnCoinDestroyed;

            _coins.Add(coin);

            yield return new WaitForSeconds(SpawnCooldown);
        }

        StopCreated?.Invoke();
    }

    private CoinTypes GetRamdomType() {
        return (CoinTypes)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CoinTypes)).Length);
    }

    private void MoveCoinToFreeSpawnPoint(Coin coin) {
        CoinSpawnPoint freeSpawnPoint = GetFreeSpawnPoint();
        freeSpawnPoint.Init(coin);
        coin.transform.position = freeSpawnPoint.transform.position;
    }

    private CoinSpawnPoint GetFreeSpawnPoint() {
        List<CoinSpawnPoint> freeSpawnPoints = SpawnPoints.Where(point => point.IsEmpty == true).ToList();
        int randomIndex = UnityEngine.Random.Range(0, freeSpawnPoints.Count);
        
        return freeSpawnPoints.ElementAt(randomIndex);
    }

    private void OnCoinDestroyed(Coin coin) {
        coin.Destroyed -= OnCoinDestroyed;
        _coins.Remove(coin);
        Destroy(coin.gameObject);
    }

    private void ClearCoinsList() {
        foreach (var iCoin in _coins) {
            Destroy(iCoin.gameObject);
        }

        _coins.Clear();
    }
}

