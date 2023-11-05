using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Question3 {
    public class GameProcessDialog : Dialog {
        private const string AllColorQuestionText = "Лопни все шарики";
        private const string SameColorQuestionText = "Лопни шарики одного цвета";

        [SerializeField] private Button _backToMainMenuButton;
        [SerializeField] private TextMeshProUGUI _helpText;

        [Inject]
        private void Construct(LevelLoadingData data) {
            AddListeners();
            UpdateUI(data);
        }

        private void UpdateUI(LevelLoadingData data) {
            if (data.ConditionType == VictoryConditionTypes.AllColor)
                SetAllColorVictoryCondition();
            else
                SetSameColorVictoryCondition(data.SphereColor);
        }

        private void AddListeners() {
            _backToMainMenuButton.onClick.AddListener(BackToMainMenuButtonClick);
        }

        private void SetAllColorVictoryCondition() {
            _helpText.text = AllColorQuestionText;
            _helpText.color = Color.white;
        }

        private void SetSameColorVictoryCondition(Color color) {
            _helpText.text = SameColorQuestionText;
            _helpText.color = color;
        }

        private void BackToMainMenuButtonClick() => Close();

        public override void Dispose() => _backToMainMenuButton.onClick.RemoveListener(BackToMainMenuButtonClick);
    }
}