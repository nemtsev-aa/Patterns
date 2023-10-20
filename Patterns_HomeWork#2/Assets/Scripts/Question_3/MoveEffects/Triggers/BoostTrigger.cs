using UnityEngine;

public class BoostTrigger : MoveEffectTrigger {
    [SerializeField, Range(1.01f, 3f)] private float _multiplier;
    [SerializeField, Range(1f, 4f)] private float _timeDuration;

    private void Start() {
        MoveEffect = new BoostEffect(_multiplier, _timeDuration);
    }
}