using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpecializationDecoratorConfig", menuName = "DecoratorConfig/SpecializationDecoratorConfig")]
public class SpecializationDecoratorConfig : DecoratorConfig {
    [field: SerializeField] public Modifiers Archer { get; private set; }
    [field: SerializeField] public Modifiers Mage { get; private set; }
    [field: SerializeField] public Modifiers Warrior { get; private set; }

    public override List<Modifiers> GetModifiers() {
        return new List<Modifiers> {
            Archer,
            Mage,
            Warrior
        };
    }
}