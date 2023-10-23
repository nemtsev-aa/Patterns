using UnityEngine;

public class DamageTrigger : HealthBaseTrigger {
    private IDamage _damager;

    protected DamageTrigger(bool isRespawned, IDamage damager) {
        IsRespawned = isRespawned;
        TimeDuration = damager.TimeDuration;

        _damager = damager;
    }

    protected override void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IDamageable damageTaker)) {
            damageTaker.TakeDamage(_damager);
            HideTrigger();
        }
    }
}