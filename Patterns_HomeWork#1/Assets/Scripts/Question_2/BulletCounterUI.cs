using TMPro;
using UnityEngine;

public class BulletCounterUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _bulletCounterText;

    public void UpdateText(int value) {
        if (_bulletCounterText == null) return;
        _bulletCounterText.text = $"{value}";
    }
}
