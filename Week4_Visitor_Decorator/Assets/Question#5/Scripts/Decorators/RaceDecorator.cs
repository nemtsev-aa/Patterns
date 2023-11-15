using System;

public class RaceDecorator : StatsDecorator {
    private readonly Races _race;
    private readonly RaceDecoratorConfig _config;

    public RaceDecorator(IStatsProvider wrappedEntity, Races race, RaceDecoratorConfig config) : base(wrappedEntity) {
        _race = race;
        _config = config;
    }

    protected override CharacterStats GetStatsInternal() {
        return _wrappedEntity.GetStats() * GetRaceStats();
    }

    private CharacterStats GetRaceStats() {
        Modifiers raceModifiers;

        switch (_race) {
            case Races.Dark:
                raceModifiers = _config.Dark;
                break;
            case Races.High:
                raceModifiers = _config.High;
                break;
            case Races.Wood:
                raceModifiers = _config.Wood;
                break;
            default:
                throw new ArgumentNullException($"Race not find {_race}");
        }

        return new CharacterStats() {
            Strength = raceModifiers.StrengthModifier,
            Intelligence = raceModifiers.IntelligenceModifier,
            Agility = raceModifiers.AgilityModifier
        };
    }
}
