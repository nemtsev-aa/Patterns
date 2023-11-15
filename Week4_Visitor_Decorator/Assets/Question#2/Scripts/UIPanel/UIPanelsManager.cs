using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIPanelsManager : MonoBehaviour, IDisposable {
    public event Action<UIPanel> ActivePanelChanged;

    [SerializeField] private List<UIPanel> _panels;
    private UIPanelVisitor _panelVisitor;

    public IEnumerable<UIPanel> Panels => _panels;
    public UIPanel ActivePanel => _panelVisitor.Panel;
    
    public void Init() {
        InitPanels();
        _panelVisitor = new UIPanelVisitor(_panels);
        ShowActivePanel();
    }

    public void SwitchPanel(UIPanel panel) {
        panel.Hide();
        _panelVisitor.Visit(panel);
        ShowActivePanel();
    }

    public void Dispose() {
        foreach (var iPanel in _panels) {
           iPanel.Closed -= SwitchPanel;
        }
    }

    private void InitPanels() {
        foreach (var iPanel in _panels) {
            iPanel.Closed += SwitchPanel;
        }

        _panels[0].Hide();
    }
    
    private void ShowActivePanel() {
        ActivePanel.Show();
        ActivePanelChanged?.Invoke(ActivePanel);
    }

    private class UIPanelVisitor : IUIPanelVisitor {
        private readonly IEnumerable<UIPanel> _panels;
        
        public UIPanelVisitor(IEnumerable<UIPanel> panels) {
            _panels = panels;
            Panel = _panels.ElementAt(0);
        }

        public UIPanel Panel { get; private set; }

        public void Visit(UIPanel panel) => Visit((dynamic)panel);

        public void Visit(GamePanel game) => Panel = _panels.FirstOrDefault(panel => panel is WinPanel);

        public void Visit(ShopPanel shop) => Panel = _panels.FirstOrDefault(panel => panel is GamePanel);

        public void Visit(WinPanel win) => Panel = _panels.FirstOrDefault(panel => panel is ShopPanel);

    }
}
