using UnityEngine;

namespace Assets.Visitor
{
    public class VisitorBootstrap: MonoBehaviour {
        [SerializeField] private int _maxWeight = 11;
        [SerializeField] private Spawner _spawner;

        private Score _score;
        private EnemiesWeightCounter _weightCounter;

        private void Awake() {
            _score = new Score(_spawner);
            _weightCounter = new EnemiesWeightCounter(_spawner, _maxWeight);
            _weightCounter.MaxWeightReached += _spawner.StopWork;

            _spawner.StartWork();
        }

        private void Update() {
            if(Input.GetKeyUp(KeyCode.Space))
                _spawner.KillRandomEnemy();
        }
    }
}
