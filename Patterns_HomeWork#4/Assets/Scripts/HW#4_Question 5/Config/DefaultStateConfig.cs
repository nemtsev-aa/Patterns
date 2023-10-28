using UnityEngine;

[CreateAssetMenu(fileName = "DefaultStateConfig", menuName = "DecoratorConfig/DefaultStateConfig")]
public class DefaultStateConfig : DecoratorConfig {
    [SerializeField] private Modifiers _defaultState;

    public Modifiers DefaultState => _defaultState;
}
