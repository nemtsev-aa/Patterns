using UnityEngine;
using System;

[Serializable]
public class RaceSelectorViewConfig : SelectorViewConfig {
    [field: SerializeField] public Races Race { get; private set; }
    public override void OnValidate() {
        base.OnValidate();

        Name = Race.ToString();
    }
}
