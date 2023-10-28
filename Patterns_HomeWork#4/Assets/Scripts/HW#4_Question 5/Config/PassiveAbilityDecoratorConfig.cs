using UnityEngine;

[CreateAssetMenu(fileName = "PassiveAbilityDecoratorConfig", menuName = "DecoratorConfig/PassiveAbilityDecoratorConfig")]
public class PassiveAbilityDecoratorConfig : DecoratorConfig {
    [SerializeField] private Modifiers StrengthBoostModifier;
    [SerializeField] private Modifiers IntelligenceBoostModifier;
    [SerializeField] private Modifiers AgilityBoostModifier;

    public Modifiers StrengthBoost => StrengthBoostModifier;
    public Modifiers IntelligenceBoost => IntelligenceBoostModifier;
    public Modifiers AgilityBoost => AgilityBoostModifier;
}
