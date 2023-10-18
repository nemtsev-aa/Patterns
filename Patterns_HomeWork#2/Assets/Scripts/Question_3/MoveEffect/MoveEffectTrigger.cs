using UnityEngine;

public class MoveEffectTrigger : MonoBehaviour {
    [SerializeField] private MoveEffect _moveEffect;
    [SerializeField] private bool _isRespawned = false;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.TryGetComponent(out Character character)) {
            character.MoveEffector.SetMoveEffect(_moveEffect);
            HideTrigger();
        }
    }

    private void ShowTrigger() {
        gameObject.SetActive(true);
    }

    private void HideTrigger() {
        if (_isRespawned == false)
        {
            Destroy(gameObject);
        }
        else 
        {
            gameObject.SetActive(false);
            Invoke(nameof(ShowTrigger), _moveEffect.Duration);
        }
    }
}
