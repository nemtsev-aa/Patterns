using System;
using UnityEngine;

[Serializable]
public class HealerConfig : ObjectConfig { 
    [SerializeField] private HealingTrigger _prefab;

    public HealingTrigger Prefab => _prefab;
}
