using UnityEngine;

public class SwitchingMediator {
    private readonly UIPanelsManager _panelsManager;
    private readonly ResourcesFactoriesSwitcher _factoriesSwitcher;

    public SwitchingMediator(UIPanelsManager panelsManager, ResourcesFactoriesSwitcher factoriesSwitcher) {
        _panelsManager = panelsManager;
        _factoriesSwitcher = factoriesSwitcher;

        _panelsManager.ActivePanelChanged += SwitchPanel;
    }

    ~SwitchingMediator() => _panelsManager.ActivePanelChanged -= SwitchPanel;

    private void SwitchPanel(UIPanel panel) {
        AbstractResourcesFactory factory = _factoriesSwitcher.GetFactory(panel);

        Sprite coinSprite = factory.GetCoin().Sprite;
        Sprite energySprite = factory.GetEnergy().Sprite;

        panel.UpdateIcons(coinSprite, energySprite);
    }
}
