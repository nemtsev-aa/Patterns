using System;
using TMPro;
using UnityEngine;

public class BulletCounterUI : MonoBehaviour, IDisposable {
    [SerializeField] private TextMeshProUGUI _bulletCounterText;
    private BulletCounter _counter;

    public void Init(BulletCounter counter) {
        _counter = counter;
        counter.BulletsCountChanged += UpdateText;
    }

    public void UpdateText(int value) {
        if (_bulletCounterText == null)
            return;
        
        _bulletCounterText.text = $"{value}";
    }

    public void Dispose() {
        _counter.BulletsCountChanged -= UpdateText;
    }
}
