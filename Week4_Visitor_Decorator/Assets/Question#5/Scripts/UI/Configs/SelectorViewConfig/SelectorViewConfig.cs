using System;
using UnityEngine;

[Serializable]
public class SelectorViewConfig : UICompanentConfig {
    private string _name;
    private Sprite _icon;

    public Sprite Icon => _icon;

    public string Name {
        get { return _name; }
        set {
            if (value == "")
                throw new ArgumentException($"{Name}: invalid value");

            _name = value;
        }
    }
    
    public override void OnValidate() {
        if (Icon == null)
            throw new ArgumentNullException($"{Icon}: is null");
    }

    public void SetIcon(Sprite icon) {
        _icon = icon;
    }
}
