public class MoveEffectBase : IMoveEffect {
    protected float _multiplier;
    protected float _timeDuration;

    public float Multiplier => _multiplier;
    public float TimeDuration => _timeDuration;
}