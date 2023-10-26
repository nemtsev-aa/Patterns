using UnityEngine;
using UnityEngine.UI;

public class DefeatPanel : UIPanel {
    [SerializeField] private Button _restart;
    
    private void OnEnable() {
        _restart.onClick.AddListener(OnRestartClick);
    }

    private void OnDisable() {
        _restart.onClick.RemoveListener(OnRestartClick);
    }

    private void OnRestartClick() => Mediator.RestartLevel();
}
