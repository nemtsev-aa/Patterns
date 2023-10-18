using UnityEngine.InputSystem;

public class WalkingState : GroundedState {
    private readonly WalkingStateConfig _config;
    public WalkingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.WalkingStateConfig;

    public override void Enter() {
        base.Enter();

        View.StartWalking();

        SetWalkingSpeed();
    }

    public override void Exit() {
        base.Exit();

        View.StopWalking();
    }

    public override void Update() {
        base.Update();

        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsBoostInput() && IsHorizontalInputZero() == false) 
            StateSwitcher.SwitchState<FastRunningState>();
    }

    protected override void AddInputActionsCallbacks() {
        base.AddInputActionsCallbacks();

        Input.Movement.Boost.performed += OnBoostKeyPressed;
    }

    protected override void RemoveInputActionsCallbacks() {
        base.RemoveInputActionsCallbacks();

        Input.Movement.Boost.performed -= OnBoostKeyPressed;
    }

    private void OnBoostKeyPressed(InputAction.CallbackContext obj) => StateSwitcher.SwitchState<RunningState>();

    private void SetWalkingSpeed() {
        /* Не смог разобраться в тем, как правильно избегать сброса эффектов движения во время смены
         * направления движения или прехеода между состояниями ходтба/бег */
        Data.Speed = _config.Speed;
    }
}
