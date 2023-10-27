using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Score
    {
        public int Value => _enemyVisitor.Score;

        private IEnemyDeathNotifier _enemyDeathNotifier;

        private EnemyVisitor _enemyVisitor;

        public Score(IEnemyDeathNotifier enemyDeathNotifier)
        {
            _enemyDeathNotifier = enemyDeathNotifier;
            _enemyDeathNotifier.Notified += OnEnemyKilled;

            _enemyVisitor = new EnemyVisitor();
        }

        ~Score() => _enemyDeathNotifier.Notified -= OnEnemyKilled;

        public void OnEnemyKilled(Enemy enemy)
        {
            _enemyVisitor.Visit(enemy);
            Debug.Log($"—чет: {Value}");
        }

        private class EnemyVisitor : IEnemyVisitor
        {
            public int Score { get; private set; }

            public void Visit(Ork ork) => Score += 20;

            public void Visit(Human human) => Score += 5;

            public void Visit(Elf elf) => Score += 10;

            public void Visit(Enemy enemy) => Visit((dynamic)enemy);

            public void Visit(Robot robot) => Score += 15;
        }
    }
}
