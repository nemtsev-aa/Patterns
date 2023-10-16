using UnityEngine;

public class EnemyCharacter : Character {
    [SerializeField] private Health _health;
    
    public void SetMaxHP(int value) {
        MaxHealth = value;
        _health.SetMax(value);
        _health.SetCurrent(value);
    }

    public void RestoreHP(int newValue) {
        _health.SetCurrent(newValue);
    }

    public void ApplyDamage(int damage) {
        _health.ApplyDamage(damage);
    }
}
