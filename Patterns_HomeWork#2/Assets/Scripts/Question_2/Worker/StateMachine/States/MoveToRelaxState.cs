using UnityEngine;

public class MoveToRelaxState : MoveToPointState {
    public MoveToRelaxState(IStateSwitcher stateSwitcher, Transform targetTransform, IMovable mover) : base(stateSwitcher, targetTransform, mover) {
    }

    protected override void OnReachTarget() {
        StateSwitcher.SwitchState<RelaxingState>();
    }
}
