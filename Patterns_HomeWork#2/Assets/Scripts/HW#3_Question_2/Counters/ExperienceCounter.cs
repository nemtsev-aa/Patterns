using System;
using UnityEngine;

public class ExperienceCounter : IService {
    private AnimationCurve _experienceCurve;
    private int _experience;
    private int _nextLevelExperience;
    private int _level = 0;
    private int _maxLevel;

    private CoinCounter _coinCounter;

    public ExperienceCounter(AnimationCurve experienceCurve, int maxLevel, CoinCounter coinCounter) {
        _experienceCurve = experienceCurve;
        _maxLevel = maxLevel;
        _nextLevelExperience = (int)_experienceCurve.Evaluate(1);

        _coinCounter = coinCounter;
        _coinCounter.CoinsCountChanged += AddExperience;
    }

    public event Action<int, int> ExperienceCountChanged;
    public event Action<int> ExperienceLevelChanged;
    public event Action MaxLevelReached;

    public void DisplayExperience() => ExperienceCountChanged?.Invoke(_experience, _nextLevelExperience);

    public void DisplayExperienceLevel() => ExperienceLevelChanged?.Invoke(_level);

    private void AddExperience(int value) {
        if (value <=0) 
            throw new ArgumentOutOfRangeException($"Invalid experience parameter: {value}");

        _experience += value;

        int excess = _experience - _nextLevelExperience;
        
        if (excess >= 0 ) {
            _experience = excess;
            ExperienceLevelUp();
        }

        DisplayExperience();
    }

    public void Reset() {
        _experience = 0;
        _level = 0;
        _nextLevelExperience = (int)_experienceCurve.Evaluate(_level);

        DisplayExperience();
        DisplayExperienceLevel();
    }

    private void ExperienceLevelUp() {
        _level++;
        DisplayExperienceLevel();

        if (_level >= _maxLevel)
            MaxLevelReached?.Invoke();
        else
            _nextLevelExperience = (int)_experienceCurve.Evaluate(_level);
    }
}
