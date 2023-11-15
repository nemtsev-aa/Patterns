using System;

public class PassiveAbilityDecorator : StatsDecorator {
    private readonly PassiveAbilitys _ability;
    private readonly PassiveAbilityDecoratorConfig _config;

    public PassiveAbilityDecorator(IStatsProvider wrappedEntity, PassiveAbilitys ability, PassiveAbilityDecoratorConfig config) : base (wrappedEntity) {
        _ability = ability;
        _config = config;
    }

    protected override CharacterStats GetStatsInternal() {
        return _wrappedEntity.GetStats() + GetPassiveAbilitiesStats(_ability);
    }

    private CharacterStats GetPassiveAbilitiesStats(PassiveAbilitys _ability) {
        Modifiers abilityModifiers;

        switch (_ability) {
            case PassiveAbilitys.Strength:
                abilityModifiers = _config.StrengthBoost;
                break;
            case PassiveAbilitys.Intelligence:
                abilityModifiers = _config.IntelligenceBoost;
                break;
            case PassiveAbilitys.Agility:
                abilityModifiers = _config.AgilityBoost;
                break;
            default:
                throw new ArgumentNullException($"Specialization not find {_ability}");
        }

        return new CharacterStats() {
            Strength = abilityModifiers.StrengthModifier,
            Intelligence = abilityModifiers.IntelligenceModifier,
            Agility = abilityModifiers.AgilityModifier
        };
    }
}
