public interface IMoveEffect {
    float SpeedMultiplier { get; }
    float Duration { get; }

    void Init(Character character);
    void TakeEffect();
    void ResetEffect();
}

