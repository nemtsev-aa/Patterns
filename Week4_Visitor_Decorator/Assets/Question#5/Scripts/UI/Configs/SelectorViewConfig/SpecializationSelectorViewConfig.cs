using UnityEngine;
using System;

[Serializable]
public class SpecializationSelectorViewConfig : SelectorViewConfig {
    [field: SerializeField] public Specializations Specialization { get; private set; }
    public override void OnValidate() {
        base.OnValidate();

        Name = Specialization.ToString();
    }
}
