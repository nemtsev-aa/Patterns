using System;

public class RaceDecorator : StateDecorator {
    private Race _race;
    private RaceDecoratorConfig _config;

    public RaceDecorator(Stats stats, Race race, RaceDecoratorConfig config) : base(stats) {
        _race = race;
        _config = config;

        Modifiers raceModifiers;

        switch (race) {
            case Race.Orc:
                raceModifiers = _config.Ork;
                break;
            case Race.Elf:
                raceModifiers = _config.Elf;
                break;
            case Race.Human:
                raceModifiers = _config.Human;
                break;
            default:
                throw new ArgumentNullException($"Race not find {race}");
        }

        ModifyStats(raceModifiers.StrengthModifier, raceModifiers.IntelligenceModifier, raceModifiers.AgilityModifier);
    }
}
