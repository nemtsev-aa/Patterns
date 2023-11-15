using UnityEngine;

public class VisitorBootstrap : MonoBehaviour {
    [Header("Configs")]
    [SerializeField] private EnemiesWeightConfig _weightConfig;
    [SerializeField] private EnemiesConfig _enemiesConfig;
    [Header("Services")]
    [SerializeField] private CreateEnemiesPanel _panel;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private EnemyFactory _factory;
    [Header("Settings")]
    [SerializeField, Range(1, 40)] private int _maxWeightLimit;

    private Score _score;
    private EnemiesWeightCounter _weightCounter;
    private EnemiesCreateMediator _enemiesCreateMediator;

    private void Awake() {
        _score = new Score(_spawner);
        _weightCounter = new EnemiesWeightCounter(_spawner, _weightConfig);
        _spawner.Init(_weightCounter, _enemiesConfig, _factory);
        _enemiesCreateMediator = new EnemiesCreateMediator(_panel, _spawner, _maxWeightLimit);
    }
}

