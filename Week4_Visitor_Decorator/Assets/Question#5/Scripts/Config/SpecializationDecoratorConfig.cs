using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecializationDecoratorConfig", menuName = "DecoratorConfig/SpecializationDecoratorConfig")]
public class SpecializationDecoratorConfig : DecoratorConfig {
    [field: SerializeField] public Modifiers Archer { get; private set; }
    [field: SerializeField] public Modifiers Mage { get; private set; }
    [field: SerializeField] public Modifiers Warrior { get; private set; }

    public override Dictionary<string, Modifiers> GetDictionaryStringModifiers() {
        return new Dictionary<string, Modifiers> {
            { $"{Specializations.Archer}", Archer },
            { $"{Specializations.Mage}", Mage },
            { $"{Specializations.Warrior}", Warrior }
        };
    }

    public Dictionary<Specializations, Modifiers> GetDictionaryEnumModifiers() {
        return new Dictionary<Specializations, Modifiers> {
            { Specializations.Archer, Archer },
            { Specializations.Mage, Mage },
            { Specializations.Warrior, Warrior }
        };
    }
}