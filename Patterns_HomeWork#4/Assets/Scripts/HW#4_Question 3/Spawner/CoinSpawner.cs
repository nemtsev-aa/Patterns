using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinSpawner : ObjectsSpawnerBase {
    [SerializeField] private CoinFactory _coinFactory;
    private List<Coin> _coins;

    public event Action StartCreated;
    public event Action StopCreated;

    public override void Reset() {
        StopWork();

        foreach (var iCoin in _coins) {
            Destroy(iCoin.gameObject);
        }

        _coins.Clear();
    }

    protected override IEnumerator SpawnObjects() {
        StartCreated?.Invoke();
       
        _coins = new List<Coin>();

        for (int i = 0; i < SpawnPoints.Count; i++) {
            Coin coin = _coinFactory.Get(GetRamdomType(), transform);
            coin.transform.position = GetRandomPosition();
            coin.Destroyed += OnDestroyed;

            _coins.Add(coin);

            yield return new WaitForSeconds(SpawnCooldown);
        }

        StopCreated?.Invoke();
    }

    private CoinType GetRamdomType() {
        return (CoinType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CoinType)).Length);
    }

    private Vector3 GetRandomPosition() {
        if (_coins.Count >= SpawnPoints.Count) 
            return Vector3.zero;

        while (true) {
            int randonIndex = UnityEngine.Random.Range(0, SpawnPoints.Count);
            Vector3 randomPosition = SpawnPoints.ElementAt(randonIndex).position;
            bool check = _coins.Any(coin => coin.transform.position == randomPosition);

            if (check == false)
                return randomPosition;
        }
    }

    private void OnDestroyed(Coin coin) {
        coin.Destroyed -= OnDestroyed;
        _coins.Remove(coin);
        Destroy(coin.gameObject);
    }
}
    
