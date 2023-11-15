using UnityEngine;
using System;

[Serializable]
public class PanelViewConfig : UICompanentConfig {
    [field: SerializeField] public Color HeaderColor { get; private set; }
    [field: SerializeField] public Sprite Frame { get; private set; }

    public override void OnValidate() {
        if (HeaderColor == Color.clear)
            throw new ArgumentNullException($"{HeaderColor}: is null");

        if (Frame == null)
            throw new ArgumentNullException($"{Frame}: is null");
    }
}
