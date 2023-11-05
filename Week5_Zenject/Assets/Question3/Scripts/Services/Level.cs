using System;
using System.Linq;

namespace Question3 {
    public class Level : IService {
        private SpheresSpawner _spawner;
        private SpheresPlacer _placer;

        public Level(SpheresSpawner spawner, SpheresPlacer placer) {
            _placer = placer;
            _spawner = spawner;
            _spawner.SpawnPositions = _placer.Positions;
        }

        public event Action Prepared;

        public void SpawnSpheres() {
            _spawner.SpheresSpawned += SpawnedComplite;
            _spawner.StartWork();
        }

        private void SpawnedComplite() {
            Prepared?.Invoke();
        }

        public void Restart() {
            if (_spawner.Spheres.Count() > 0)
                ClearSpheres();
        }

        public void ClearSpheres() => _spawner.Restart();
    }
}