using System;
using UnityEngine;

[Serializable]
public class DamagerConfig : ObjectConfig {
    [SerializeField] private DamageTrigger _prefab;

    public DamageTrigger Prefab => _prefab;
}
