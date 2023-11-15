using System;
using UnityEngine;

[Serializable]
public class StatViewConfig : UICompanentConfig {
    [field: SerializeField] public StateTypes Type { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }

    public override void OnValidate() {
        if (Icon == null)
            throw new ArgumentNullException($"{Icon}: is null");
    }
}
