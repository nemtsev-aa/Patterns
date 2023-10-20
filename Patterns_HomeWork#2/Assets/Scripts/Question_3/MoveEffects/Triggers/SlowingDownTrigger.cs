using System;
using UnityEngine;

public class SlowingDownTrigger : MoveEffectTrigger {
    [SerializeField, Range(0.01f, 0.99f)] private float _multiplier;
    [SerializeField, Range(1f, 4f)] private float _timeDuration;
    
    private void Start() {
        MoveEffect = new SlowingDownEffect(_multiplier, _timeDuration);
    }
}