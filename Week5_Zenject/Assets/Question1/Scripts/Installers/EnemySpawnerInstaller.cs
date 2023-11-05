using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawnerInstaller : MonoInstaller {
    [SerializeField] private float _spawnCooldown = 2f;
    [SerializeField] private List<Transform> _spawnPoints;

    public override void InstallBindings()
    {
        Container.Bind<EnemyFactory>().AsSingle();
        Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().WithArguments(this, _spawnCooldown, _spawnPoints);
    }
}
