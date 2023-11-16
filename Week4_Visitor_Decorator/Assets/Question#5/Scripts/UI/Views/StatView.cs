using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatView : UICompanent {
    private StatViewConfig _config;
    [field: SerializeField] public TextMeshProUGUI HeaderText { get; private set; }
    [field: SerializeField] public Image Icon { get; private set; }
    [field: SerializeField] public TextMeshProUGUI ValueText { get; private set; }
    
    public StateTypes Type { get; private set; }

    public void Init(StatViewConfig config) {
        _config = config;
        ŅonfigureŅomponents();
    }

    public void SetValue(int value) => ValueText.text = $"{value}";

    private void ŅonfigureŅomponents() {
        HeaderText.text = $"{_config.Type}";
        Icon.sprite = _config.Icon;
        Type = _config.Type;
    }
}
