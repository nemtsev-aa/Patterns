using System;

public class Level : IService, IDisposable {
    private SpheresSpawner _spawner;
    private SpheresPlacer _placer;

    public event Action Prepared;
   
    public Level(SpheresSpawner spawner, SpheresPlacer placer, int sphereCount) {
        _spawner = spawner;
        _placer = placer;

        _placer.Init(sphereCount);
        _spawner.Init(_placer.Positions);

        _spawner.SpheresSpawned += SpawnedComplite;
    }

    private void SpawnedComplite() {
        Prepared?.Invoke();
    }

    public void Restart() {
        _spawner.Restart();
        _placer.Restart();
    }

    public void Dispose() {
        _spawner.SpheresSpawned -= SpawnedComplite;
    }
}
