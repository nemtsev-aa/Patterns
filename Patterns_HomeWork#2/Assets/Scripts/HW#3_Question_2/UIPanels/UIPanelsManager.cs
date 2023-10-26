using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIPanelsManager : MonoBehaviour, IPanelSwitcher {
    [SerializeField] private UIPanelFactory _uIPanelFactory;
    
    private List<UIPanel> _panels;
    private IPanel _activePanel;

    public void Init(GameplayMediator gameplayMediator) {
        CreatePanels(gameplayMediator);
    }

    public void ShowGamePanel() => SwitchPanel<GamePanel>();

    public void ShowDefeatPanel() => SwitchPanel<DefeatPanel>();

    public void ShowVictoryPanel() => SwitchPanel<VictoryPanel>();

    public void SwitchPanel<T>() where T : IPanel {
        IPanel panel = _panels.FirstOrDefault(panel => panel is T);

        if (_activePanel != null)
            _activePanel.Hide();

        _activePanel = panel;
        _activePanel.Show();
    }

    private void CreatePanels(GameplayMediator gameplayMediator) {
        RectTransform parent = this.GetComponent<RectTransform>();
        _panels = new List<UIPanel>();
        _panels.Add(_uIPanelFactory.Get(UIPanelType.Game, parent));
        _panels.Add(_uIPanelFactory.Get(UIPanelType.Defeat, parent));
        _panels.Add(_uIPanelFactory.Get(UIPanelType.Victory, parent));

        foreach (var iPanel in _panels) {
            iPanel.transform.SetParent(transform);
            iPanel.Init(gameplayMediator);
        }
    }
}