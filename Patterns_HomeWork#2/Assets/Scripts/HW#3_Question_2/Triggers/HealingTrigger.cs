using System;
using UnityEngine;

public class HealingTrigger : HealthBaseTrigger {
    private IHealth _healer;
    
    public void SetHealer(IHealth healer) {
        _healer = healer; 
    }

    protected override void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IDamageable healingeTaker)) {
            healingeTaker.TakeHealing(_healer);
            HideTrigger();
        }
    }
}