using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Visitor {
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier, IEnemyCreatedNotifier {
        public event Action<Enemy> Notified;
        public event Action<Enemy> Created;

        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;

        [SerializeField] private EnemyConfigs _enemyConfigs;
        [SerializeField] private VisitorEnemyFactory _visitorFactory;

        private List<Enemy> _spawnedEnemies = new List<Enemy>();

        private Coroutine _spawn;


        public void StartWork()
        {
            StopWork();
            _visitorFactory.Init();
            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)].Kill();
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                Enemy enemy = _visitorFactory.Get(_enemyConfigs.GetRandonConfig());
                enemy.MoveTo(GetRandomPosition());
                enemy.Died += OnEnemyDied;
                enemy.transform.SetParent(transform);

                _spawnedEnemies.Add(enemy);
                
                Created?.Invoke(enemy);

                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private Vector3 GetRandomPosition() {
            if (_spawnedEnemies.Count >= _spawnPoints.Count)
                return Vector3.zero;

            while (true) {
                int randonIndex = UnityEngine.Random.Range(0, _spawnPoints.Count);
                Vector3 randomPosition = _spawnPoints.ElementAt(randonIndex).position;
                bool check = _spawnedEnemies.Any(enemy => enemy.transform.position == randomPosition);

                if (check == false)
                    return randomPosition;
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
    }
}
