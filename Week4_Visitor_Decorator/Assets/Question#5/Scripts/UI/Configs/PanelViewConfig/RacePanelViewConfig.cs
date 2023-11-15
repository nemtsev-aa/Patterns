using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class RacePanelViewConfig : PanelViewConfig {
    [SerializeField] private List<RaceSelectorViewConfig> _selectorConfigs;
    public IEnumerable<RaceSelectorViewConfig> SelectorConfigs => _selectorConfigs;
}
