using UnityEngine;

[CreateAssetMenu(fileName = "SpecializationDecoratorConfig", menuName = "DecoratorConfig/SpecializationDecoratorConfig")]
public class SpecializationDecoratorConfig : DecoratorConfig {
    [SerializeField] private Modifiers ThiefModifier;
    [SerializeField] private Modifiers MageModifier;
    [SerializeField] private Modifiers BarbarianModifier;

    public Modifiers Thief => ThiefModifier;
    public Modifiers Mage => MageModifier;
    public Modifiers Barbarian => BarbarianModifier;
}