using UnityEngine;

public abstract class HealthBaseTrigger : MonoBehaviour {
    [SerializeField] protected bool IsRespawned = false;
    [SerializeField, Range(1f, 5f)] protected int Value;
    [SerializeField, Range(1f, 3f)] protected float TimeDuration;

    protected virtual void ShowTrigger() {
        gameObject.SetActive(true);
    }
    
    protected abstract void OnTriggerEnter(Collider other);
   
    protected virtual void HideTrigger() {
        gameObject.SetActive(false);

        if (IsRespawned == false)
            Destroy(gameObject, TimeDuration);
        else
            Invoke(nameof(ShowTrigger), TimeDuration);
    }
}