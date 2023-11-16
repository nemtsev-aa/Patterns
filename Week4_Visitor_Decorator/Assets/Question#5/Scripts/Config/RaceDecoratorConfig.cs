using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "RaceDecoratorConfig", menuName = "DecoratorConfig/RaceDecoratorConfig")]
public class RaceDecoratorConfig : DecoratorConfig {
    [field: SerializeField] public Modifiers Dark { get; private set; }
    [field: SerializeField] public Modifiers High { get; private set; }
    [field: SerializeField] public Modifiers Wood { get; private set; }

    public override Dictionary<string, Modifiers> GetDictionaryStringModifiers() {
        return new Dictionary<string, Modifiers> {
            { $"{Races.Dark}", Dark },
            { $"{Races.High}", High },
            { $"{Races.Wood}", Wood }
        };
    }

    public Races GetKeyByValue(Modifiers value) {
        Dictionary<Races, Modifiers> dictionary = new Dictionary<Races, Modifiers> {
            { Races.Dark, Dark },
            { Races.High, High },
            { Races.Wood, Wood }
        };

        return dictionary.FirstOrDefault(x => x.Value.Equals(value)).Key;
    }
}
