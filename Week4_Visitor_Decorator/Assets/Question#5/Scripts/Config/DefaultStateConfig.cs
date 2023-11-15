using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStateConfig", menuName = "DecoratorConfig/DefaultStateConfig")]
public class DefaultStateConfig : DecoratorConfig {
    [SerializeField] private Modifiers _defaultState;

    public Modifiers DefaultState => _defaultState;

    public override List<Modifiers> GetModifiers() {
        return new List<Modifiers> {
            _defaultState
        };
    }
}
