using System;

namespace Assets.Visitor {
    public interface IEnemyCreatedNotifier {
        event Action<Enemy> Created;
    }
}
