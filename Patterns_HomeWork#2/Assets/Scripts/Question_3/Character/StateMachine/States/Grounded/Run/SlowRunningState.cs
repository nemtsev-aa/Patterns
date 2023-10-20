public class SlowRunningState : BaseRunningState {

    public SlowRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) {
    }
    
    public override void Enter() {
        base.Enter();
        View.StartSlowRunning();
     
        SetSpeed();
    }

    public override void Update() {
        base.Update();

        if (IsCtrlDown)
            return;

        StateSwitcher.SwitchState<RunningState>();
    }

    public override void Exit() {
        base.Exit();
        View.StopSlowRunning();
       
    }

    protected override void SetSpeed() => Data.Speed = Config.SlowSpeed * SpeedMultiplier;
}
