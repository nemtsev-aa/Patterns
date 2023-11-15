public class Character {
    private IStatsProvider _provider;

    public IStatsProvider Provider => _provider;

    public Character(Races race, Specializations specialization, PassiveAbilitys ability, DecoratorConfigs decoratorConfigs) {
        var defaultState = decoratorConfigs.GetConfigByType<DefaultStateConfig>();
        _provider = new DefaultDecorator(defaultState);

        _provider = new RaceDecorator(_provider, race, decoratorConfigs.GetConfigByType<RaceDecoratorConfig>());
        _provider = new SpecializationDecorator(_provider, specialization, decoratorConfigs.GetConfigByType<SpecializationDecoratorConfig>());
        _provider = new PassiveAbilityDecorator(_provider, ability, decoratorConfigs.GetConfigByType<PassiveAbilityDecoratorConfig>());
    }
}
