using System;
using UnityEngine;

public class PanelsManager : MonoBehaviour, IDisposable {
    public event Action<UIPanel> ActivePanelChanged;

    [SerializeField] private GamePanel _gamePanel;
    [SerializeField] private ShopPanel _shopPanel;

    private UIPanel _activePanel;
    
    public void Init() {
        _gamePanel.Init();
        _gamePanel.Closed += SwichPanel;
        _shopPanel.Init();
        _shopPanel.Closed += SwichPanel;

        _activePanel = _shopPanel;
        SwichPanel(_activePanel);
    }

    public void SwichPanel(UIPanel panel) {
        panel.Hide();
        _activePanel = panel is GamePanel ? _activePanel = _shopPanel : _activePanel = _gamePanel;
        _activePanel.Show();

        ActivePanelChanged?.Invoke(_activePanel);
    }

    public void Dispose() {
        _gamePanel.Closed -= SwichPanel;
        _shopPanel.Closed -= SwichPanel;
    }
}
