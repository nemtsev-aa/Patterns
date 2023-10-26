using System;
using UnityEngine;

[Serializable]
public class GeneralParametersConfig {
    [SerializeField, Range(0, 5)] private int _maxHealth;
    [SerializeField] private AnimationCurve _experienceCurve;
    [SerializeField, Range(0, 3)] private int _maxLevel;

    public int MaxHealth => _maxHealth;
    public AnimationCurve ExperienceCurve => _experienceCurve;
    public int MaxLevel => _maxLevel;
}
