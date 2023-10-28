using UnityEngine;

public class Bootstraper : MonoBehaviour {
    [SerializeField] private PanelsManager _panelsManager;
    [SerializeField] private SpriteFactoriesSwitcher _factoriesSwitcher;

    private SwitchingMediator _switchingMediator;
   
    private void Awake() {
        _switchingMediator = new SwitchingMediator(_panelsManager, _factoriesSwitcher);
        _panelsManager.Init();
    }
}
