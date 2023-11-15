public class DefaultDecorator : IStatsProvider {
    private readonly DefaultStateConfig _config;

    public DefaultDecorator(DefaultStateConfig config) {
        _config = config;
    }

    public CharacterStats GetStats() {
        return new CharacterStats() {
            Strength = _config.DefaultState.StrengthModifier,
            Intelligence = _config.DefaultState.IntelligenceModifier,
            Agility = _config.DefaultState.AgilityModifier
        };
    }
}
