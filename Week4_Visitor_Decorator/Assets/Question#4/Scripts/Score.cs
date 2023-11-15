using UnityEngine;

public class Score {
    private readonly IEnemyDeathNotifier _enemyDeathNotifier;
    private readonly EnemyScoreVisitor _enemyVisitor;

    public Score(IEnemyDeathNotifier enemyDeathNotifier) {
        _enemyDeathNotifier = enemyDeathNotifier;
        _enemyDeathNotifier.Notified += OnEnemyKilled;

        _enemyVisitor = new EnemyScoreVisitor();
    }

    ~Score() => _enemyDeathNotifier.Notified -= OnEnemyKilled;

    public int Value => _enemyVisitor.Score;

    public void OnEnemyKilled(Enemy enemy) {
        _enemyVisitor.Visit(enemy.Config);
        Debug.Log($"—чет: {Value}");
    }

    private class EnemyScoreVisitor : IEnemyConfigVisitor {
        public int Score { get; private set; }

        public void Visit(EnemyConfig enemy) => Visit((dynamic)enemy);

        public void Visit(OrkConfig ork) => Score += 20;

        public void Visit(HumanConfig human) => Score += 5;

        public void Visit(ElfConfig elf) => Score += 10;

        public void Visit(RobotConfig robot) => Score += 15;

        public void Visit(DwarfConfig dwarf) => Score += 25;
    }
}

