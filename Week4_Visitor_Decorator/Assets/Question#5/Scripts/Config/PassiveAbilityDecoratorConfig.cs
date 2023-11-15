using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PassiveAbilityDecoratorConfig", menuName = "DecoratorConfig/PassiveAbilityDecoratorConfig")]
public class PassiveAbilityDecoratorConfig : DecoratorConfig {
    [field: SerializeField] public Modifiers StrengthBoost { get; private set; }
    [field: SerializeField] public Modifiers IntelligenceBoost { get; private set; }
    [field: SerializeField] public Modifiers AgilityBoost { get; private set; }
    
    public override List<Modifiers> GetModifiers() {
        return new List<Modifiers> {
            StrengthBoost,
            IntelligenceBoost,
            AgilityBoost
        };
    }
}
