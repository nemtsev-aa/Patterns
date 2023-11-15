using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Configs/EnemiesConfig")]
public class EnemiesConfig : ScriptableObject {
    [SerializeField] private List<EnemyConfig> _enemyConfigsList;

    public EnemyConfig GetEnemyConfig<T>() {
        if (_enemyConfigsList.Count == 0)
            throw new ArgumentNullException($"EnemyConfigList is empty {_enemyConfigsList}");

        return _enemyConfigsList.FirstOrDefault(config => config is T);
    }

    public EnemyConfig GetRandomConfig() {
        if (_enemyConfigsList.Count == 0)
            throw new ArgumentNullException($"EnemyConfigList is empty {_enemyConfigsList}");

        return _enemyConfigsList[UnityEngine.Random.Range(0, _enemyConfigsList.Count)];
    }
}
