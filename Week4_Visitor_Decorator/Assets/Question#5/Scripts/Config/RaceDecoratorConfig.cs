using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RaceDecoratorConfig", menuName = "DecoratorConfig/RaceDecoratorConfig")]
public class RaceDecoratorConfig : DecoratorConfig {
    [field: SerializeField] public Modifiers Dark { get; private set; }
    [field: SerializeField] public Modifiers High { get; private set; }
    [field: SerializeField] public Modifiers Wood { get; private set; }

    public override List<Modifiers> GetModifiers() {
        return new List<Modifiers> {
            Dark,
            High,
            Wood
        };
    }
}
