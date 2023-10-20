using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Configs/CharacterConfig")]
public class CharacterConfig : ScriptableObject {
    [SerializeField] private AirborneStateConfig _airborneStateConfig;
    [SerializeField] private WalkingStateConfig _walkingStateConfig;
    [SerializeField] private RunningStateConfig _runningStateConfig;
    [SerializeField] private float _speedMultiplier;

    public float SpeedMultiplier {
        get => _speedMultiplier;
        set {
            if (value <= 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _speedMultiplier = value;
        }
    }

    public AirborneStateConfig AirborneStateConfig => _airborneStateConfig;
    public WalkingStateConfig WalkingStateConfig => _walkingStateConfig;
    public RunningStateConfig RunningStateConfig => _runningStateConfig; 
}
