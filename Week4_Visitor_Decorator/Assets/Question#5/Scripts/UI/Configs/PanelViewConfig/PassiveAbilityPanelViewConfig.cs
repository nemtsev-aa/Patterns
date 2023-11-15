using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PassiveAbilityPanelViewConfig : PanelViewConfig {
    [SerializeField] private List<PassiveAbilitySelectorViewConfig> _selectorConfigs;
    public IEnumerable<PassiveAbilitySelectorViewConfig> SelectorConfigs => _selectorConfigs;
}
