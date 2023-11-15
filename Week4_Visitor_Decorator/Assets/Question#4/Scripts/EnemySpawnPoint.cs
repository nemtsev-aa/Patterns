using UnityEngine;


public class EnemySpawnPoint : MonoBehaviour {
    private Enemy _enemy;

    public bool IsEmpty {
        get {
            if (_enemy == null)
                return true;
            else
                return false;
        }
    }

    public void Init(Enemy enemy) {
        _enemy = enemy;
    }

    public void Reset() {
        _enemy = null;
    }
}
