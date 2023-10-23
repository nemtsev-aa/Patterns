using TMPro;
using UnityEngine;

public class LevelView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Bar _bar;

    private ExperienceCounter _experienceCounter;
    
    public void Init(ExperienceCounter expCounter) {
        _experienceCounter = expCounter;
        _experienceCounter.ExperienceCountChanged += _bar.Display;
        _experienceCounter.LevelChanged += DisplayLevel;
    }

    private void DisplayLevel(int level) {
        _levelText.text = $"Level: {level}";
    }
}