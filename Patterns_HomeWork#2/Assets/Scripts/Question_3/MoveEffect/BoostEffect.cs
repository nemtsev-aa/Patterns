
public class BoostEffect : MoveEffect {

    private void OnValidate() {
        if (_speedMultiplier <= 0)
            _speedMultiplier = 1;
    }

    public override void TakeEffect() {
        base.TakeEffect();
    }

    public override void SetSpeedInConfigs(float speedMultiplier) {
        _stateMachineData.Speed = _speedDefault * speedMultiplier;
    }

    public override void SetSpeedMultiplierInView(float speedMultiplier) {
        float multiplier = speedMultiplier;
        _characterView.SetSpeedMultiplier(multiplier);
    }

    public override void ResetEffect() {
        SetSpeedInConfigs(MultiplierDefault);
        SetSpeedMultiplierInView(MultiplierDefault);
    }
}
