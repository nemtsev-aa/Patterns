using TMPro;
using UnityEngine;

public class HealthView : MonoBehaviour {
    [SerializeField] private Bar _bar;
    [SerializeField] private TextMeshProUGUI _text;

    private Health _health;

    public void Init(Health health) {
        _health = health;

        _bar.Init();

        _health.HealthCountChanged += _bar.Display;
        _health.HealthCountChanged += ShowText;

        _health.ShowHealth();
    }

    private void ShowText(int currentExperience, int nextLevelExperience) {
        _text.text = $"{currentExperience}/{nextLevelExperience}";
    }
    
    private void OnDisable() {
        _health.HealthCountChanged -= _bar.Display;
        _health.HealthCountChanged -= ShowText;
    }
}