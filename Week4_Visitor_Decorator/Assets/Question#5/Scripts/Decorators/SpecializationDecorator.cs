using System;

public class SpecializationDecorator : StatsDecorator {
    private readonly Specializations _specialization;
    private readonly SpecializationDecoratorConfig _config;

    public SpecializationDecorator(IStatsProvider wrappedEntity, Specializations specialization, SpecializationDecoratorConfig config) : base(wrappedEntity) {
        _specialization = specialization;
        _config = config;
    }

    protected override CharacterStats GetStatsInternal() {
        return _wrappedEntity.GetStats() + GetSpecializationcStats();
    }

    public CharacterStats GetSpecializationcStats() {
        Modifiers specModifiers;

        switch (_specialization) {
            case Specializations.Archer:
                specModifiers = _config.Archer;
                break;
            case Specializations.Mage:
                specModifiers = _config.Mage;
                break;
            case Specializations.Warrior:
                specModifiers = _config.Warrior;
                break;
            default:
                throw new ArgumentNullException($"Specialization not find {_specialization}");
        }

        return new CharacterStats(){
            Strength = specModifiers.StrengthModifier,
            Intelligence = specModifiers.IntelligenceModifier,
            Agility = specModifiers.AgilityModifier
        };
    }
}
