using System;

public class PassiveAbilityDecorator : StateDecorator {
    private PassiveAbility _ability;
    private PassiveAbilityDecoratorConfig _config;
    public PassiveAbilityDecorator(Stats stats, PassiveAbility ability, PassiveAbilityDecoratorConfig config) : base(stats) {
        _ability = ability;
        _config = config;

        Modifiers abilityModifiers;
        
        switch (ability) {
            case PassiveAbility.StrengthBoost:
                abilityModifiers = _config.StrengthBoost;
                break;
            case PassiveAbility.IntelligenceBoost:
                abilityModifiers = _config.IntelligenceBoost;
                break;
            case PassiveAbility.AgilityBoost:
                abilityModifiers = _config.AgilityBoost;
                break;
            default:
                throw new ArgumentNullException($"Specialization not find {ability}");
        }

        ModifyStats(abilityModifiers.StrengthModifier, abilityModifiers.IntelligenceModifier, abilityModifiers.AgilityModifier);
    }
}
