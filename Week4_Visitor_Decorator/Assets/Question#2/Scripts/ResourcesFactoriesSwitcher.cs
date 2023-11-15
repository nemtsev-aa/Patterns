using System.Collections.Generic;

public class ResourcesFactoriesSwitcher {
    private readonly UIPanelVisitor _visitor;
    
    public ResourcesFactoriesSwitcher(SpriteConfig config, IEnumerable<UIPanel> panels) {
        _visitor = new UIPanelVisitor(panels, config);
    }

    public AbstractResourcesFactory ResourcesFactory => _visitor.Factory;
    
    public AbstractResourcesFactory GetFactory(UIPanel panel) {
        _visitor.Visit(panel);
        
        return ResourcesFactory;
    }

    private class UIPanelVisitor : IUIPanelVisitor {
        private readonly IEnumerable<UIPanel> _panels;
        private readonly SpriteConfig _config;

        public UIPanelVisitor(IEnumerable<UIPanel> panels, SpriteConfig config) {
            _panels = panels;
            _config = config;
        }

        public AbstractResourcesFactory Factory { get; private set; }

        public void Visit(UIPanel panel) => Visit((dynamic)panel);

        public void Visit(GamePanel game) => Factory = new GameResourcesFactory(_config.GameCoinSprite, _config.GameEnergySprite);

        public void Visit(ShopPanel shop) => Factory = new ShopResourcesFactory(_config.ShopCoinSprite, _config.ShopEnergySprite);

        public void Visit(WinPanel win) => Factory = new WinResourcesFactory(_config.WinCoinSprite, _config.WinEnergySprite);
    }
}
