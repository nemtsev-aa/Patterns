using System;
using UnityEngine;

public class DamageTrigger : HealthBaseTrigger {
    private IDamage _damager;

    public void SetDamager(IDamage damage) {
        _damager = damage;
    }

    protected override void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IDamageable damageTaker)) {
            damageTaker.TakeDamage(_damager);
            HideTrigger();
        }
    }
}