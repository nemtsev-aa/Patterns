public class WorkingState : ActionState {
    public WorkingState(IStateSwitcher stateSwitcher, float actionTime) : base(stateSwitcher, actionTime) {
    }

    protected override void OnReachTarget() {
        StateSwitcher.SwitchState<MoveToRelaxState>();
    }
}
