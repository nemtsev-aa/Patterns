using System;
using System.Collections.Generic;
using UnityEngine;

public class CreationPanelsView : MonoBehaviour {
    public event Action ActiveSelectorChanged;

    [SerializeField] private RectTransform _panelsParent;
    [SerializeField] private List<PanelViewConfig> _panelConfigs;
    
    private DecoratorConfigs _decoratorConfigs;
    private UICompanentsFactory _uICompanentFactory;
    private PanelViewConfigVisitor _panelViewConfigVisitor;

    private readonly List<PanelView> _panels = new List<PanelView>();

    public IEnumerable<PanelView> Panels => _panels;

    public void Init(DecoratorConfigs decoratorConfigs, UICompanentsFactory uICompanentFactory) {
        _decoratorConfigs = decoratorConfigs;
        _uICompanentFactory = uICompanentFactory;
        _uICompanentFactory.Init();

        _panelViewConfigVisitor = new PanelViewConfigVisitor(_panelConfigs);
        
        CreatePanelViews();
    }

    private void CreatePanelViews() {
        foreach (var iConfig in _decoratorConfigs.Configs) {
            _panelViewConfigVisitor.Visit(iConfig);
            CreatePanelView();
        }
    }

    private void CreatePanelView() {
        PanelViewConfig panelViewConfig = _panelViewConfigVisitor.PanelViewConfig;
        PanelView newPanel = _uICompanentFactory.Get<PanelView>(panelViewConfig, _panelsParent);

        CreateSelectors(panelViewConfig, newPanel.SelectorsParent, out List<SelectorView> selectors);
        
        newPanel.Init(panelViewConfig, selectors);
        newPanel.ActiveSelectorChanged += UpdatePanelLabel;
        newPanel.ActiveSelectorChanged += UpdateStatsView;

        _panels.Add(newPanel);
    }

    private void CreateSelectors(PanelViewConfig panelConfig, RectTransform selectorsParent, out List<SelectorView> selectors) {
        selectors = new List<SelectorView>();

        foreach (var iData in panelConfig.SelectorsData) {

            SelectorViewConfig selectorViewConfig = new SelectorViewConfig(iData.Key, iData.Value);
            SelectorView newSelector = _uICompanentFactory.Get<SelectorView>(selectorViewConfig, selectorsParent);
            newSelector.Init(selectorViewConfig, panelConfig.HeaderColor, panelConfig.Frame);

            selectors.Add(newSelector);
        }
    }

    private void UpdatePanelLabel(PanelView panel, SelectorView selector) {
        panel.HeaderText.text = $"{panel.name} : {selector.Config.Name}";
    }

    private void UpdateStatsView(PanelView panel, SelectorView selector) {

    }
}
