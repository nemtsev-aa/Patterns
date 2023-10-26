using System;
using UnityEngine;

public abstract class HealthBaseTrigger : MonoBehaviour {
    protected bool IsRespawned;
    protected float Cooldown;

    public event Action<HealthBaseTrigger> Destroyed;

    public virtual void Init(bool isRespawned, float cooldown = 3f) {
        if (IsRespawned) {
            IsRespawned = isRespawned;
            Cooldown = cooldown;
        }
    }

    protected virtual void ShowTrigger() {
        gameObject.SetActive(true);
    }
    
    protected abstract void OnTriggerEnter(Collider other);
   
    protected virtual void HideTrigger() {
        gameObject.SetActive(false);

        if (IsRespawned == false)
            Destroyed?.Invoke(this);
        else
            Invoke(nameof(ShowTrigger), Cooldown);
    }
}