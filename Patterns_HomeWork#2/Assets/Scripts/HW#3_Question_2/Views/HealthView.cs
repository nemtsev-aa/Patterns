using UnityEngine;

public class HealthView : MonoBehaviour {
    [SerializeField] private Bar _bar;

    private Health _health;

    public void Init(Health health) {
        _health = health;
        _health.HealthCountChanged += _bar.Display;
    }
}