using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class PanelViewConfig : UICompanentConfig {
    [field: SerializeField] public Color HeaderColor { get; private set; }
    [field: SerializeField] public Sprite Frame { get; private set; }
    [field: SerializeField] public PanelTypes Type { get; private set; }
    public Dictionary<string, Sprite> SelectorsData { get; private set; }
    
    public override void OnValidate() {
        if (HeaderColor == Color.clear)
            throw new ArgumentNullException($"{HeaderColor}: is null");

        if (Frame == null)
            throw new ArgumentNullException($"{Frame}: is null");
    }

    internal void SetSelectorsData(Dictionary<string, Sprite> selectorsData) {
        SelectorsData = selectorsData;
    }
}
