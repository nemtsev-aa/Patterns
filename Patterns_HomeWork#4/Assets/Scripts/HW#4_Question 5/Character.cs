public class Character {
    public Stats Stats { get; private set; }

    public Character(Race race, Specialization specialization, PassiveAbility ability, DecoratorConfigs decoratorConfigs) {
        var defaultState = decoratorConfigs.GetConfigByType<DefaultStateConfig>().DefaultState;
        Stats = new Stats(defaultState.StrengthModifier, defaultState.IntelligenceModifier, defaultState.AgilityModifier);

        Stats = new RaceDecorator(Stats, race, decoratorConfigs.GetConfigByType<RaceDecoratorConfig>());
        Stats = new SpecializationDecorator(Stats, specialization, decoratorConfigs.GetConfigByType<SpecializationDecoratorConfig>());
        Stats = new PassiveAbilityDecorator(Stats, ability, decoratorConfigs.GetConfigByType<PassiveAbilityDecoratorConfig>());
    }
}
