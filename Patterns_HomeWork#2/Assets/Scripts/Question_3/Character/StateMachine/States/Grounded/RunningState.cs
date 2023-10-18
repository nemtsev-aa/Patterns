using System;

public class RunningState : GroundedState
{
    private readonly RunningStateConfig _config;
    private float _timer;

    public RunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.RunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartRunning();
        SetRunningSpeed();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopRunning();
    }

    public override void Update() {
        base.Update();
      
        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsBoostInput() == false)
            StateSwitcher.SwitchState<WalkingState>();
    }

    private void SetRunningSpeed() {
        /* Не смог разобраться в тем, как правильно избегать сброса эффектов движения во время смены
         * направления движения или прехеода между состояниями ходтба/бег */

        Data.Speed = _config.Speed;
    }
}
