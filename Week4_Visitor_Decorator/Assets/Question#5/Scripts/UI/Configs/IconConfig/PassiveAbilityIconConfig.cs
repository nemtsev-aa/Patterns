using UnityEngine;
using System;

[Serializable]
public class PassiveAbilityIconConfig : IconConfig {
    [field: SerializeField] public PassiveAbilitys PassiveAbility { get; private set; }
}

