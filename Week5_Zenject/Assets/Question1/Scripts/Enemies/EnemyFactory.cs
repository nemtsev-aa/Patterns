using System;
using System.IO;
using UnityEngine;
using Zenject;

public class EnemyFactory {
    private const string SmallConfig = "SmallConfig";
    private const string MediumConfig = "MediumConfig";
    private const string LargeConfig = "LargeConfig";
    private const string ConfigsPath = "EnemyConfigs";

    private EnemyConfig _small, _medium, _large;
    private DiContainer _container;

    public EnemyFactory(DiContainer container)
    {
        _container = container;
        Load();
        Debug.Log("Factory init");
    }

    public Enemy Get(EnemyTypes enemyType)
    {
        EnemyConfig config = GetConfig(enemyType);
        Enemy instance = _container.InstantiatePrefabForComponent<Enemy>(config.Prefab);
        instance.Initialize(config.Health, config.Speed);
        return instance;
    }

    private void Load()
    {
        _small = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, SmallConfig));
        _medium = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, MediumConfig));
        _large = Resources.Load<EnemyConfig>(Path.Combine(ConfigsPath, LargeConfig));
    }

    private EnemyConfig GetConfig(EnemyTypes enemyType)
    {
        switch (enemyType)
        {
            case EnemyTypes.Small:
                return _small;

            case EnemyTypes.Medium:
                return _medium;

            case EnemyTypes.Large:
                return _large;

            default:
                throw new ArgumentException(nameof(enemyType));
        }
    }
}
