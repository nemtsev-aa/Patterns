using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpecializationPanelViewConfig : PanelViewConfig {
    [SerializeField] private List<SpecializationSelectorViewConfig> _selectorConfigs;
    public IEnumerable<SpecializationSelectorViewConfig> SelectorConfigs => _selectorConfigs;
}
