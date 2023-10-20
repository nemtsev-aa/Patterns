using System;

public class RunningState : BaseRunningState {
    
    private float _timer;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) {
    }
        

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();
        SetSpeed();
    }

    public override void Update() {
        base.Update();

        if (IsShiftDown)
            StateSwitcher.SwitchState<FastRunningState>();

        if (IsCtrlDown)
            StateSwitcher.SwitchState<SlowRunningState>();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

protected override void SetSpeed() => Data.Speed = Config.Speed * SpeedMultiplier;
}
