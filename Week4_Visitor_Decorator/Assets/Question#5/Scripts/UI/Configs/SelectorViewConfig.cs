using System;
using UnityEngine;

[Serializable]
public class SelectorViewConfig : UICompanentConfig {
    public SelectorViewConfig(string name, Sprite icon) {
        Name = name;
        Icon = icon;
    }

    public Sprite Icon { get; private set; }

    public string Name { get; private set; }

    public override void OnValidate() {
        if (Icon == null)
            throw new ArgumentNullException($"{Icon}: is null");
    }
}
