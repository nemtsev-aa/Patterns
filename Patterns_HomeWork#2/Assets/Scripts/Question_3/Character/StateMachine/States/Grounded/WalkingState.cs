using UnityEngine.InputSystem;

public class WalkingState : GroundedState {
    private readonly WalkingStateConfig _config;
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WalkingStateConfig;

    public override void Enter() {
        base.Enter();

        View.StartSlowRunning();

        SetWalkingSpeed();
    }

    public override void Exit() {
        base.Exit();

        View.StopSlowRunning();
    }

    public override void Update() {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        //if (IsBoostInput() && IsHorizontalInputZero() == false) 
        //    StateSwitcher.SwitchState<FastRunningState>();
    }

    private void SetWalkingSpeed() {
        Data.Speed = _config.Speed;
    }
}
