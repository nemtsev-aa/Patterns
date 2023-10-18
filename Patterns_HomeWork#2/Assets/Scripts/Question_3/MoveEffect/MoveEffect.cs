using UnityEngine;
/* Предпринял попытку реализовать эффекты изменяющие скорость персонажа.
 * Прошу дать совет относительно более качественной реализации */
public class MoveEffect : MonoBehaviour, IMoveEffect {
    protected const float MultiplierDefault = 1;

    [SerializeField, Range(-5, 5)] protected float _speedMultiplier;
    [SerializeField, Range(0, 5)] protected float _duration;

    protected Character _character;
    protected CharacterView _characterView;
    protected StateMachineData _stateMachineData;
    protected float _speedDefault;

    public float SpeedMultiplier => _speedMultiplier;
    public float Duration => _duration;

    public void Init(Character character) {
        _character = character;
        _characterView = _character.View;
        _stateMachineData = _character.StateMachine.Data;
        _speedDefault = _stateMachineData.Speed;
    }

    public virtual void TakeEffect() {
        SetSpeedInConfigs(SpeedMultiplier);
        SetSpeedMultiplierInView(SpeedMultiplier);

        Invoke(nameof(ResetEffect), Duration);
    }

    public virtual void SetSpeedInConfigs(float speedMultiplier) { }
    public virtual void SetSpeedMultiplierInView(float speedMultiplier) { }
    public virtual void ResetEffect() { }
}
