using UnityEngine;

public class SwitchingMediator {
    private PanelsManager _panelsManager;
    private SpriteFactoriesSwitcher _factoriesSwitcher;

    public SwitchingMediator(PanelsManager panelsManager, SpriteFactoriesSwitcher factoriesSwitcher) {
        _panelsManager = panelsManager;
        _factoriesSwitcher = factoriesSwitcher;

        _panelsManager.ActivePanelChanged += SwitchPanel;
    }

    ~SwitchingMediator() => _panelsManager.ActivePanelChanged -= SwitchPanel;

    private void SwitchPanel(UIPanel panel) {
        _factoriesSwitcher.ActivatePanel(panel.StyleType, out Sprite coinIcon, out Sprite energyIcon); ;
        panel.UpdateIcons(coinIcon, energyIcon);
    }
}
