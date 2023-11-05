using Question3;
using UnityEngine;

public class LevelLoadingData {
    private VictoryConditionTypes _conditionType;
    private Color _color;

    public LevelLoadingData(VictoryConditionTypes conditionType, Color color) {
        _conditionType = conditionType;
        _color = color;
    }

    public VictoryConditionTypes ConditionType => _conditionType;
    public Color SphereColor => _color;
}
