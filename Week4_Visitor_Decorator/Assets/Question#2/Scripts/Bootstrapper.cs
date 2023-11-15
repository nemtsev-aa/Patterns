using UnityEngine;

public class Bootstrapper : MonoBehaviour {
    [SerializeField] private UIPanelsManager _panelsManager;
    [SerializeField] private SpriteConfig _spriteConfig;

    private ResourcesFactoriesSwitcher _factoriesSwitcher;
    private SwitchingMediator _switchingMediator;
   
    private void Awake() {
        _factoriesSwitcher = new ResourcesFactoriesSwitcher(_spriteConfig, _panelsManager.Panels);
        _switchingMediator = new SwitchingMediator(_panelsManager, _factoriesSwitcher);
        _panelsManager.Init();
    }
}
