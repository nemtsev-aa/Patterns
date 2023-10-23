using System;
using UnityEngine;

public class ExperienceCounter {
    private float _experience = 0f;
    private float _nextLevelExperience = 5f;
    private AnimationCurve _experienceCurve;
    private int _level;

    public ExperienceCounter(AnimationCurve experienceCurve) {
        _experienceCurve = experienceCurve;
        _nextLevelExperience = _experienceCurve.Evaluate(0);
    }

    public event Action<float, float> ExperienceCountChanged;
    public event Action<int> LevelChanged;

    public void AddExperience(float value) {
        if (value <=0) 
            throw new ArgumentOutOfRangeException($"Invalid experience parameter: {value}");

        _experience += value;
        
        if (_experience >= _nextLevelExperience)
            UpLevel();
        
        DisplayExperience();
    }

   private void UpLevel() {
        _level++;

        DisplayLevelUp();

        _experience = 0;
        _nextLevelExperience = _experienceCurve.Evaluate(_level);
    }

    private void DisplayExperience() {
        ExperienceCountChanged?.Invoke(_experience, _nextLevelExperience);
    }

    private void DisplayLevelUp() {
        LevelChanged?.Invoke(_level);
    }
}
