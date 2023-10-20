using System;

public class CharacterEffectTaker {
    private const int DefaultSpeedMultiplier = 1;

    private CharacterConfig _config;
    private StateMachineData _stateMachineData;
    private CharacterView _view;

    private float _defaultSpeed;
    private float _multiplier;

    public CharacterEffectTaker(CharacterConfig config, StateMachineData stateMachineData, CharacterView view) {
        _config = config;
        _stateMachineData = stateMachineData;
        _view = view;
    }

    public void TakeEffect(IMoveEffect moveEffect) {
        if (moveEffect.Multiplier == 0 || moveEffect.TimeDuration == 0) 
            throw new ArgumentOutOfRangeException($"Invalid effect parameters: {moveEffect}");

        _multiplier = moveEffect.Multiplier;
        _defaultSpeed = _stateMachineData.Speed;
        SetSpeedInConfig();
        SetSpeedInView();
    }

    public void RemoveEffect() {
        _config.SpeedMultiplier = DefaultSpeedMultiplier;
        _stateMachineData.Speed = _defaultSpeed;
        _view.SetSpeedMultiplier(DefaultSpeedMultiplier);
    }

    private void SetSpeedInConfig() {
        _config.SpeedMultiplier = _multiplier;
        _stateMachineData.Speed *= _multiplier;
    }

    private void SetSpeedInView() => _view.SetSpeedMultiplier(_multiplier);
}
