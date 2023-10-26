using System;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleFactory", menuName = "Factory/ObstacleFactory")]
public class ObstacleFactory : ScriptableObject {
    [SerializeField] private DamagerConfig _small, _medium, _large;
    
    public DamageTrigger Get(DamageType type, Transform parent) {
        DamagerConfig config = GetConfig(type);
        DamageTrigger instance = Instantiate(config.Prefab, parent);
        instance.Init(false, config.TimeDuartion);
        instance.SetDamager(GetDamager(config));

        return instance;
    }

    private DamagerConfig GetConfig(DamageType type) {
        switch (type) {
            case DamageType.Small:
                return _small;

            case DamageType.Medium:
                return _medium;

            case DamageType.Large:
                return _large;

            default:
                throw new ArgumentException(nameof(type));
        }
    }

    private IDamage GetDamager(DamagerConfig config) {
        return new InstantDamager(config.Value, config.TimeDuartion);
    }
}