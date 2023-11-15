using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "DecoratorConfigs", menuName = "DecoratorConfig/DecoratorConfigs")]
public class DecoratorConfigs : ScriptableObject {
    [field: SerializeField] public List<DecoratorConfig> Configs { get; private set; }

    public T GetConfigByType<T>() where T : DecoratorConfig {
        if (Configs.Count == 0)
            throw new ArgumentNullException($"DecoratorConfigs list is empty!");

        return (T)Configs.FirstOrDefault(config => config is T);
    }
}