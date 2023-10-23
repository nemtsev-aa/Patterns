using UnityEngine;

public class HealingTrigger : HealthBaseTrigger {
    private IHealth _healer;

    protected HealingTrigger(bool isRespawned, IHealth healer) {
        IsRespawned = isRespawned;
        TimeDuration = healer.TimeDuration;

        _healer = healer;
    }

    protected override void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IDamageable healingeTaker)) {
            healingeTaker.TakeHealing(_healer);
            HideTrigger();
        }
    }
}