using UnityEngine;

public class MoveEffectTrigger : MonoBehaviour {
    [SerializeField] protected bool _isRespawned = false;
    protected IMoveEffect MoveEffect;

    protected virtual void OnTriggerEnter(Collider other) {
        if (other.TryGetComponent(out IMoveEffectTaker effectTaker)) {
            effectTaker.TakeEffect(MoveEffect);
            HideTrigger(); 
        }
    }
    
    private void ShowTrigger() {
        gameObject.SetActive(true);
    }
    
    private void HideTrigger() {
        gameObject.SetActive(false);
        
        if (_isRespawned == false) 
            Destroy(gameObject, MoveEffect.TimeDuration);
        else 
            Invoke(nameof(ShowTrigger), MoveEffect.TimeDuration);
    }
}
