using System;
using UnityEngine;

public class Health : IService {
    private int _max;
    private int _current;

    public Health(int max) {
        if (max <= 0)
            throw new ArgumentOutOfRangeException($"Invalid HealthMax parameter: {max}");

        _max = max;
        _current = _max;
    }

    public event Action<int, int> HealthCountChanged;
    public event Action HealthIsOver;

    public void ShowHealth() {
        HealthCountChanged?.Invoke(_current, _max);
    }

    public void TakeHealing(int healing) {
        if (healing <= 0)
            throw new ArgumentOutOfRangeException($"Invalid Healing parameter: {healing}");

        _current += healing;

        if (_current >= _max) 
            _current = _max;

        HealthCountChanged?.Invoke(_current, _max);
    }

    public void TakeDamage(int damage) {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException($"Invalid Damage parameter: {damage}");

        _current -= damage;

        if (_current <= 0) {
            _current = 0;
            HealthIsOver?.Invoke();
        }

        HealthCountChanged?.Invoke(_current, _max);
    }

    public void Reset() {
        _current = _max;
        ShowHealth();
    }
}