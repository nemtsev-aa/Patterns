using System;

public class SpecializationDecorator : StateDecorator {
    private Specialization _specialization;
    private SpecializationDecoratorConfig _config;

    public SpecializationDecorator(Stats stats, Specialization specialization, SpecializationDecoratorConfig config) : base(stats) {
        _specialization = specialization;
        _config = config;

        Modifiers specModifiers;

        switch (specialization) {
            case Specialization.Thief:
                specModifiers = _config.Thief;
                break;
            case Specialization.Mage:
                specModifiers = _config.Mage;
                break;
            case Specialization.Barbarian:
                specModifiers = _config.Barbarian;
                break;
            default:
                throw new ArgumentNullException($"Specialization not find {specialization}");
        }

        ModifyStats(specModifiers.StrengthModifier, specModifiers.IntelligenceModifier, specModifiers.AgilityModifier);
    }
}
