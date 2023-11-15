using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectorView : UICompanent {
    public event Action<SelectorView> MouseEnter;
    public event Action<SelectorView> MouseExit;
    public event Action<SelectorView> MouseDown;

    private SelectorViewConfig _config;
    private Color _headerColor;
    private Sprite _frame;

    [field: SerializeField] public Toggle Toggle { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public Image Frame { get; private set; }

    public SelectorViewConfig Config => _config;

    public void Init(SelectorViewConfig config, Color headerColor, Sprite frame) {
        _config = config;
        _headerColor = headerColor;
        _frame = frame;

        —onfigure—omponents();
    }

    private void —onfigure—omponents() {
        //name = $"{_config.Type}";
        Icon.sprite = _config.Icon;
        Frame.sprite = _frame;
        Frame.color = _headerColor;
        Toggle.group = transform.parent.GetComponent<ToggleGroup>();
    }

    private void OnMouseEnter() {
        MouseEnter?.Invoke(this);
    }

    private void OnMouseExit() {
        MouseExit?.Invoke(this);
    }

    private void OnMouseDown() {
        MouseDown?.Invoke(this);
    }
}
