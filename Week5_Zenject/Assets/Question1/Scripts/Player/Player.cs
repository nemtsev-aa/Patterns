using System;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour, IEnemyTarget {
    private int _maxHealth;
    private int _health;

    public Vector3 Position => transform.position;

    [Inject]
    public void Construct(PlayerStatsConfig playerStatsConfig) {
        _health = _maxHealth = playerStatsConfig.MaxHealth;
        Debug.Log($"Σ μενÿ {_health} υο");
    }

    public void TakeDamage(int damage) {
        if (damage <= 0)
            throw new ArgumentOutOfRangeException($"Invalid Damage parameter: {damage}");

        _health -= damage;

        if (_health <= 0) {
            _health = 0;
        }
    }
}
