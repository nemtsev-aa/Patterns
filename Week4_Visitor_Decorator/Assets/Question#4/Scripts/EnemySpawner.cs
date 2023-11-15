using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IEnemyDeathNotifier, IEnemyCreatedNotifier, IDisposable {
    public event Action StartCreated;
    public event Action StopCreated;
    public event Action<int> WeightFixed;

    public event Action<Enemy> Notified;
    public event Action<Enemy> Created;

    [SerializeField] private List<EnemySpawnPoint> _spawnPoints;

    private readonly float _spawnCooldown = 0.5f;
    private readonly List<Enemy> _spawnedEnemies = new List<Enemy>();

    private Coroutine _spawn;
    private EnemiesWeightCounter _weightCounter;
    private EnemiesConfig _enemyConfigs;
    private EnemyFactory _factory;

    public void Init(EnemiesWeightCounter weightCounter, EnemiesConfig enemyConfigs, EnemyFactory factory) {
        _weightCounter = weightCounter;
        _weightCounter.MaxWeightReached += StopWork;
        _weightCounter.WeightChanged += FixWeight;

        _enemyConfigs = enemyConfigs;
        _factory = factory;
    }


    public void StartWork(int maxWeight) {
        StopWork();

        _factory.Init();
        _weightCounter.SetMaxWeight(maxWeight);
        _spawn = StartCoroutine(Spawn());
    }

    public void StopWork() {
        if (_spawn != null)
            StopCoroutine(_spawn);

        StopCreated?.Invoke();
    }

    public void KillRandomEnemy() {
        if (_spawnedEnemies.Count == 0)
            return;

        _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
    }

    public void Reset() {
        foreach (var iEnemy in _spawnedEnemies) {
            iEnemy.Died -= OnEnemyDied;
            Destroy(iEnemy.gameObject);
        }

        _spawnedEnemies.Clear();

        foreach (var iPoint in _spawnPoints) {
            iPoint.Reset();
        }

        _weightCounter.Reset();
    }

    private IEnumerator Spawn() {
        StartCreated?.Invoke();

        for (int i = 0; i < _spawnPoints.Count; i++) {
            Enemy enemy = CreateEnemy();
            
            _spawnedEnemies.Add(enemy);

            yield return new WaitForSeconds(_spawnCooldown);
        }
    }

    private Enemy CreateEnemy() {
        EnemyConfig randomEnemyConfig = _enemyConfigs.GetRandomConfig();
        Enemy enemy = _factory.Get(randomEnemyConfig);
        enemy.Init(randomEnemyConfig);
        enemy.Died += OnEnemyDied;
        MoveEnemyToFreeSpawnPoint(enemy);

        Created?.Invoke(enemy);
        return enemy;
    }

    private void MoveEnemyToFreeSpawnPoint(Enemy enemy) {
        EnemySpawnPoint freeSpawnPoint = GetFreeSpawnPoint();
        freeSpawnPoint.Init(enemy);

        enemy.MoveTo(freeSpawnPoint.transform.position);
        enemy.transform.SetParent(transform);
    }

    private EnemySpawnPoint GetFreeSpawnPoint() {
        List<EnemySpawnPoint> freeSpawnPoints = _spawnPoints.Where(point => point.IsEmpty == true).ToList();
        int randomIndex = UnityEngine.Random.Range(0, freeSpawnPoints.Count);

        return freeSpawnPoints.ElementAt(randomIndex);
    }
    private void FixWeight(int value) => WeightFixed?.Invoke(value);

    private void OnEnemyDied(Enemy enemy) {
        Notified?.Invoke(enemy);
        enemy.Died -= OnEnemyDied;
        _spawnedEnemies.Remove(enemy);
    }

    public void Dispose() {
        _weightCounter.MaxWeightReached -= StopWork;
        _weightCounter.WeightChanged -= FixWeight;
    }
}

