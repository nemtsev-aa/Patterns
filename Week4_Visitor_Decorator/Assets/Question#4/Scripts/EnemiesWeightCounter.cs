using System;
using UnityEngine;

public class EnemiesWeightCounter {
    public event Action<int> WeightChanged;
    public event Action MaxWeightReached;

    private int _maxValue;
    private readonly IEnemyCreatedNotifier _enemyCreatedNotifier;
    private readonly EnemyWeightVisitor _enemyVisitor;
    
    public EnemiesWeightCounter(IEnemyCreatedNotifier enemyCreatedNotifier, EnemiesWeightConfig weightConfig) {
        _enemyCreatedNotifier = enemyCreatedNotifier;
        _enemyCreatedNotifier.Created += OnEnemyCreated;

        _enemyVisitor = new EnemyWeightVisitor(weightConfig);
    }

    ~EnemiesWeightCounter() => _enemyCreatedNotifier.Created -= OnEnemyCreated;
    
    private int Value => _enemyVisitor.Weight;
    
    public void SetMaxWeight(int maxWeight) {
        _maxValue = maxWeight;
    }

    private void OnEnemyCreated(Enemy enemy) {
        _enemyVisitor.Visit(enemy.Config);
        ShowCurrentWeight();

        if (Value > _maxValue)
            MaxWeightReached?.Invoke();
    }

    private void ShowCurrentWeight() {
        WeightChanged?.Invoke(Value);
    }

    public void Reset() {
        _enemyVisitor.Reset();
        ShowCurrentWeight();
    }
}
