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


    private class EnemyVisitor : IEnemyVisitor {
        private const int OrkWeight = 5;
        private const int HumanWeight = 2;
        private const int ElfWeight = 1;
        private const int RobotWeight = 3;

        public int Weight { get; private set; }

        public void Visit(Enemy enemy) => Visit((dynamic)enemy);

        public void Visit(Ork ork) => Weight += OrkWeight;

        public void Visit(Human human) => Weight += HumanWeight;

        public void Visit(Elf elf) => Weight += ElfWeight;

        public void Visit(Robot robot) => Weight += RobotWeight;
    }
}
