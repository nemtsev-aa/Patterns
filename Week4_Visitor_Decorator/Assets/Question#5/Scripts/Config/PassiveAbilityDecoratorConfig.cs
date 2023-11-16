using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveAbilityDecoratorConfig", menuName = "DecoratorConfig/PassiveAbilityDecoratorConfig")]
public class PassiveAbilityDecoratorConfig : DecoratorConfig {
    [field: SerializeField] public Modifiers StrengthBoost { get; private set; }
    [field: SerializeField] public Modifiers IntelligenceBoost { get; private set; }
    [field: SerializeField] public Modifiers AgilityBoost { get; private set; }

    public override Dictionary<string, Modifiers> GetDictionaryStringModifiers() {
        return new Dictionary<string, Modifiers> {
            { $"{PassiveAbilitys.Strength}" , StrengthBoost },
            { $"{PassiveAbilitys.Intelligence}" , IntelligenceBoost },
            { $"{PassiveAbilitys.Agility}", AgilityBoost }
        };
    }

    public Dictionary<PassiveAbilitys, Modifiers> GetDictionaryEnumModifiers() {
        return new Dictionary<PassiveAbilitys, Modifiers> {
            { PassiveAbilitys.Strength, StrengthBoost },
            { PassiveAbilitys.Intelligence, IntelligenceBoost },
            { PassiveAbilitys.Agility, AgilityBoost }
        };
    }
}
