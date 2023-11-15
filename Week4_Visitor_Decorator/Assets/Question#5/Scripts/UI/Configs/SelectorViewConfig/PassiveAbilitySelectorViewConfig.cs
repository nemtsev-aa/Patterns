using UnityEngine;
using System;

[Serializable]
public class PassiveAbilitySelectorViewConfig : SelectorViewConfig {
    [field: SerializeField] public PassiveAbilitys PassiveAbility { get; private set; }

    public override void OnValidate() {
        base.OnValidate();

        Name = PassiveAbility.ToString();
    }
}
