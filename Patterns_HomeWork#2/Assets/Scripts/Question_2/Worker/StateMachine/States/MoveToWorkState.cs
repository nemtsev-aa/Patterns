using UnityEngine;

public class MoveToWorkState : MoveToPointState {
    public MoveToWorkState(IStateSwitcher stateSwitcher, Transform targetTransform, IMovable mover) : base(stateSwitcher, targetTransform, mover) {
    }

    protected override void OnReachTarget() {
        StateSwitcher.SwitchState<WorkingState>();
    }
}
