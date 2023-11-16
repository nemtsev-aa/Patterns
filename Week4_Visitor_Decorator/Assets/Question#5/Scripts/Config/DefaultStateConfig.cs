using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStateConfig", menuName = "DecoratorConfig/DefaultStateConfig")]
public class DefaultStateConfig : DecoratorConfig {
    [SerializeField] private Modifiers _defaultState;

    public Modifiers DefaultState => _defaultState;

    public override Dictionary<string, Modifiers> GetDictionaryStringModifiers() {
        return new Dictionary<string, Modifiers> {
            {"default", _defaultState }
        };
    }
}
