using System.Collections.Generic;
using UnityEngine;

public class CharacterCreationView : MonoBehaviour {
    [SerializeField] private RectTransform _panelsParent;
    [SerializeField] private List<PanelViewConfig> _panelConfigs;
    [SerializeField] private DecoratorConfigs _decoratorConfigs;

    private List<PanelView> _panels = new List<PanelView>();
    private UICompanentsFactory _uICompanentFactory;

    public void Init(UICompanentsFactory uICompanentFactory) {
        _uICompanentFactory = uICompanentFactory;
        _uICompanentFactory.Init();

        CreatePanels();
    }

    private void CreatePanels() {
        foreach (var iConfig in _decoratorConfigs.Configs) {

        }

        RaceDecoratorConfig race = _decoratorConfigs.GetConfigByType<RaceDecoratorConfig>();
        
        
    }

    private void UpdatePanelLabel(PanelView panel, SelectorView selector) {
        //panel.HeaderText.text = $"{panel.name} : {selector.Config.Name}";
    }

    private void CreatePanelViewConfig() {

    }

    //private void CreatePanelView() {

    //    PanelView newPanel = _uICompanentFactory.Get<PanelView>(iPanel, _panelsParent);

    //    CreateSelectors(iPanel, newPanel.SelectorsParent, out List<SelectorView> selectors);
    //    newPanel.Init(iPanel, selectors);
    //    newPanel.ActiveSelectorChanged += UpdatePanelLabel;

    //    _panels.Add(newPanel);
    //}

    private void CreateSelectors(PanelViewConfig panelConfig, RectTransform selectorsParent, out List<SelectorView> selectors) {
        selectors = new List<SelectorView>();
        
        //foreach (var iSelector in panelConfig.SelectorConfigs) {
        //    SelectorView newSelector = _uICompanentFactory.Get<SelectorView>(iSelector, selectorsParent);
        //    newSelector.Init(iSelector, panelConfig.HeaderColor);

        //    selectors.Add(newSelector);
        //}
    }
}
