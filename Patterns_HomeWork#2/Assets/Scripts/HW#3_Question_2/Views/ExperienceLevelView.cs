using TMPro;
using UnityEngine;

public class ExperienceLevelView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI _experienceText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Bar _bar;

    private ExperienceCounter _experienceCounter;
    
    public void Init(ExperienceCounter expCounter) {
        _experienceCounter = expCounter;
        
        _bar.Init();

        _experienceCounter.ExperienceCountChanged += _bar.Display;
        _experienceCounter.ExperienceCountChanged += DisplayExperienceText;
        _experienceCounter.ExperienceLevelChanged += DisplayLevel;
        
        _experienceCounter.DisplayExperience();
        _experienceCounter.DisplayExperienceLevel();
    }

    private void DisplayExperienceText(int currentExperience, int nextLevelExperience) {
        _experienceText.text = $"{currentExperience}/{nextLevelExperience}";
    }

    private void DisplayLevel(int level) {
        _levelText.text = $"{level}";
    }

    private void OnDisable() {
        _experienceCounter.ExperienceCountChanged -= _bar.Display;
        _experienceCounter.ExperienceCountChanged -= DisplayExperienceText;
        _experienceCounter.ExperienceLevelChanged -= DisplayLevel;
    }
}