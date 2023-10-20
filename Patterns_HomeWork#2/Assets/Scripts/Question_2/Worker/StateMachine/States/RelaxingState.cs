public class RelaxingState : ActionState {
    public RelaxingState(IStateSwitcher stateSwitcher, float actionTime) : base(stateSwitcher, actionTime) {
    }

    protected override void OnReachTarget() {
        StateSwitcher.SwitchState<MoveToWorkState>();
    }
}
