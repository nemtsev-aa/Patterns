public abstract class BaseRunningState : GroundedState {
    private const float KeyDown = 1;

    protected RunningStateConfig Config;
    protected float SpeedMultiplier;

    public BaseRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character) {
        Config = character.Config.RunningStateConfig;
        SpeedMultiplier = character.Config.SpeedMultiplier;
    }

    public bool IsShiftDown => Input.Movement.FastRun.ReadValue<float>() == KeyDown;
    public bool IsCtrlDown => Input.Movement.SlowRun.ReadValue<float>() == KeyDown;

    public override void Enter() {
        base.Enter();

        View.StartRunning();
    }

    public override void Exit() {
        base.Exit();

        View.StopRunning();
    }

    public override void Update() {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();
    }

    protected abstract void SetSpeed();
}
