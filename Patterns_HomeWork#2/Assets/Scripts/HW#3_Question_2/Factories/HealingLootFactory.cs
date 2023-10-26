using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealingLootFactory", menuName = "Factory/HealingLootFactory")]
public class HealingLootFactory : ScriptableObject {
    [SerializeField] private HealerConfig _small, _medium, _large;

    public HealingTrigger Get(HealingLootType type, Transform parent) {
        HealerConfig config = GetConfig(type);
        HealingTrigger instance = Instantiate(config.Prefab, parent);
        instance.Init(false, config.TimeDuartion);
        instance.SetHealer(GetHealer(config));
        
        return instance;
    }

    private HealerConfig GetConfig(HealingLootType type) {
        switch (type) {
            case HealingLootType.Small:
                return _small;

            case HealingLootType.Medium:
                return _medium;

            case HealingLootType.Large:
                return _large;

            default:
                throw new ArgumentException(nameof(type));
        }
    }

    private IHealth GetHealer(HealerConfig config) {
        return new InstantHealer(config.Value, config.TimeDuartion);
    }
}
