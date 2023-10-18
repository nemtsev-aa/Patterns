using UnityEngine;

public class FastRunningState : GroundedState
{
    private readonly FastRunningStateConfig _config;
    private float _timer;

    public FastRunningState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
        => _config = character.Config.FastRunningStateConfig;

    public override void Enter()
    {
        base.Enter();

        View.StartFastRunning();

        SetFastRunningSpeed();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopFastRunning();
    }

    public override void Update() {
        base.Update();
      
        if (IsHorizontalInputZero())
            StateSwitcher.SwitchState<IdlingState>();

        if (IsBoostInput() == false)
            StateSwitcher.SwitchState<WalkingState>();
    }

    private void SetFastRunningSpeed() {
        /* �� ���� ����������� � ���, ��� ��������� �������� ������ �������� �������� �� ����� �����
        * ����������� �������� ��� �������� ����� ����������� ������/��� */
        Data.Speed = _config.Speed;
    }
}
