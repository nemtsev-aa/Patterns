using Assets.Visitor;
using System;
using UnityEngine;

public class EnemiesWeightCounter {
    public event Action MaxWeightReached;
    public int _maxValue;
    private int _value => _enemyVisitor.Weight;

    private IEnemyCreatedNotifier _enemyCreatedNotifier;
    private EnemyVisitor _enemyVisitor;

    public EnemiesWeightCounter(IEnemyCreatedNotifier enemyCreatedNotifier, int maxValue) {
        _enemyCreatedNotifier = enemyCreatedNotifier;
        _enemyCreatedNotifier.Created += OnEnemyCreated;

        _maxValue = maxValue;

        _enemyVisitor = new EnemyVisitor();
    }

    ~EnemiesWeightCounter() => _enemyCreatedNotifier.Created += OnEnemyCreated;

    private void OnEnemyCreated(Enemy enemy) {
        _enemyVisitor.Visit(enemy);

        if (_value > _maxValue) {
            MaxWeightReached?.Invoke();
        }

        Debug.Log($"Общий вес: {_value}");
    }
}
