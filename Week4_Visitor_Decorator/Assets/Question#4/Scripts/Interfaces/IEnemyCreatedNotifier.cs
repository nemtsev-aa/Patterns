using System;

public interface IEnemyCreatedNotifier {
    event Action<Enemy> Created;
}

