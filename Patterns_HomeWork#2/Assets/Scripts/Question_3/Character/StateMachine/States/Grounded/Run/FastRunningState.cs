public class FastRunningState : BaseRunningState {
    private float _timer;

    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) {
    }

    public override void Enter() {
        base.Enter();
        
        View.StartFastRunning();

        SetSpeed();
    }

    public override void Exit() {
        base.Exit();
       
        View.StopFastRunning();
    }

    public override void Update() {
        base.Update();

        if (IsShiftDown)
            return;

        StateSwitcher.SwitchState<RunningState>();
    }

    protected override void SetSpeed() => Data.Speed = RunProperties.FastSpeed;
    
}
