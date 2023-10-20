public class SlowingDownEffect : MoveEffectBase { 
    public SlowingDownEffect(float multiplier, float timeDuration) {
        _multiplier = multiplier;
        _timeDuration = timeDuration;
    }
}
