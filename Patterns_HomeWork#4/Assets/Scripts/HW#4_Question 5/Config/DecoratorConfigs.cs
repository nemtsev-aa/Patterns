using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DecoratorConfigs", menuName = "DecoratorConfig/DecoratorConfigs")]
public class DecoratorConfigs : ScriptableObject {
    [SerializeField] private List<DecoratorConfig> _configs;

    public T GetConfigByType<T>() where T : DecoratorConfig {
        if (_configs.Count == 0)
            throw new ArgumentNullException($"DecoratorConfigs list is empty!");

        return (T)_configs.FirstOrDefault(config => config is T);
    }
}