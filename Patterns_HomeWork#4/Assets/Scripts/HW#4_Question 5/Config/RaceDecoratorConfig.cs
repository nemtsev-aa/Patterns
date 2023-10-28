using UnityEngine;

[CreateAssetMenu(fileName = "RaceDecoratorConfig", menuName = "DecoratorConfig/RaceDecoratorConfig")]
public class RaceDecoratorConfig : DecoratorConfig {
    [SerializeField] private Modifiers OrkModifier;
    [SerializeField] private Modifiers ElfModifier;
    [SerializeField] private Modifiers HumanModifier;

    public Modifiers Ork => OrkModifier;
    public Modifiers Elf => ElfModifier;
    public Modifiers Human => HumanModifier;
}
