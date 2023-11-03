using System;

public class VictoryConditionFactory {
    private InputSystem _inputSystem;
    private SpheresSpawner _spawner;

    public VictoryConditionFactory(InputSystem inputSystem, SpheresSpawner spawner) {
        _inputSystem = inputSystem;
        _spawner = spawner;
    }

    public VictoryCondition GetVictoryCondition(VictoryConditionTypes conditionType) {
        switch (conditionType) {
            case VictoryConditionTypes.SameColor:
                return new SameColorSphereDestroyed(_spawner.Spheres, _inputSystem);

            case VictoryConditionTypes.AllColor:
                return new AllSphereDestroyed(_spawner.Spheres, _inputSystem);

            default:
                throw new ArgumentException(nameof(conditionType));
        }
    }
}
