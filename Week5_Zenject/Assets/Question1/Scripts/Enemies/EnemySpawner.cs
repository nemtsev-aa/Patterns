using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : IPause {
    private EnemyFactory _enemyFactory;
    private float _spawnCooldown;
    private IReadOnlyList<Transform> _spawnPoints;

    private MonoBehaviour _context;
    private Coroutine _spawn;
    private List<Enemy> _spawnedEnemies = new List<Enemy>();
    private int _limitToCreate = 0;

    private bool _isPaused;

    public EnemySpawner(EnemyFactory enemyFactory, PauseHandler pauseHandler, MonoBehaviour context, float spawnCooldown, IReadOnlyList<Transform> spawnPoints, int limitToCreate = 0) {
        _enemyFactory = enemyFactory;
        _context = context;
        _spawnCooldown = spawnCooldown;
        _spawnPoints = spawnPoints;
        _limitToCreate = limitToCreate;

        pauseHandler.Add(this);
    }

    public void StartWork() {
        StopWork();

        _spawn = _context.StartCoroutine(Spawn());
    }

    public void StopWork() {
        if (_spawn != null)
            _context.StopCoroutine(_spawn);
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;

    private IEnumerator Spawn() {
        float time = 0;

        while (true)
        {
            while(time < _spawnCooldown)
            {
                if(_isPaused == false)
                    time += Time.deltaTime;

                yield return null;
            }

            if (_limitToCreate == 0)
                CreateEnemy();
            else
                while (_spawnedEnemies.Count <=_limitToCreate) {
                    CreateEnemy();
                }

            time = 0;
        }
    }

    private void CreateEnemy() {
        Enemy enemy = _enemyFactory.Get((EnemyTypes)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyTypes)).Length));
        enemy.MoveTo(GetRandonSpawnPointPosition());
        enemy.Destroyed += OnEnemyDestroyed;
        _spawnedEnemies.Add(enemy);
    }

    private Vector3 GetRandonSpawnPointPosition() {
        int randomIndex = UnityEngine.Random.Range(0, _spawnPoints.Count());
        return _spawnPoints.ElementAt(randomIndex).position;
    }

    private void OnEnemyDestroyed(Enemy enemy) {
        enemy.Destroyed -= OnEnemyDestroyed;
        _spawnedEnemies.Remove(enemy);
    }
}
