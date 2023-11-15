using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PanelView : UICompanent, IDisposable {
    public event Action<PanelView, SelectorView> ActiveSelectorChanged;

    private PanelViewConfig _config;
    private List<SelectorView> _selectors;

    [field: SerializeField] public TextMeshProUGUI HeaderText { get; private set; }
    [field: SerializeField] public Image HeaderImage { get; private set; }
    [field: SerializeField] public RectTransform SelectorsParent { get; private set; }

    public PanelViewConfig Config => _config;
    
    public void Init(PanelViewConfig config, List<SelectorView> selectors) {
        _config = config;
        _selectors = selectors;

        ÑonfigureÑomponents();
    }

    private void ÑonfigureÑomponents() {
        //name = $"{_config.Type}";
        HeaderImage.color = _config.HeaderColor;
        HeaderText.text = name;

        foreach (var iSelector in _selectors) {
            iSelector.Toggle.onValueChanged.AddListener((value) => ActivateSelector(value, iSelector));
        }
    }

    private void ActivateSelector(bool value, SelectorView selector) {
        if (value == true)
            ActiveSelectorChanged?.Invoke(this, selector);
    }

    public void Dispose() {
        foreach (var iSelector in _selectors) {
            iSelector.Toggle.onValueChanged.RemoveListener((value) => ActivateSelector(value, iSelector));
        }
    }
}
