using System;

public class CharacterEffectTaker {
    private const int DefaultSpeedMultiplier = 1;

    private UnitRunningProperties _runProperties;
    private StateMachineData _stateMachineData;
    private CharacterView _view;

    private float _defaultSpeed;
    private float _multiplier;

    public CharacterEffectTaker(UnitRunningProperties runProperties, StateMachineData stateMachineData, CharacterView view) {
        _runProperties = runProperties;
        _stateMachineData = stateMachineData;
        _view = view;
    }

    public void TakeEffect(IMoveEffect moveEffect) {
        if (moveEffect.Multiplier == 0 || moveEffect.TimeDuration == 0) 
            throw new ArgumentOutOfRangeException($"Invalid effect parameters: {moveEffect}");

        _multiplier = moveEffect.Multiplier;
        _defaultSpeed = _stateMachineData.Speed;
        SetSpeedInProperties();
        SetSpeedInView();
    }

    public void RemoveEffect() {
        _runProperties.SpeedMultiplier = DefaultSpeedMultiplier;
        _stateMachineData.Speed = _defaultSpeed;
        _view.SetSpeedMultiplier(DefaultSpeedMultiplier);
    }

    private void SetSpeedInProperties() {
        _runProperties.SpeedMultiplier = _multiplier;
        _stateMachineData.Speed *= _multiplier;
    }

    private void SetSpeedInView() => _view.SetSpeedMultiplier(_multiplier);
}
