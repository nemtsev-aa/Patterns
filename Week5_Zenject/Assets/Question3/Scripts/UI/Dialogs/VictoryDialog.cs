using System;
using UnityEngine;
using UnityEngine.UI;

namespace Question3 {
    public class VictoryDialog : Dialog {
        [SerializeField] private Button _backToMainMenuButton;
        [SerializeField] private Button _restartLevelButton;
 
        public event Action LevelRestartClick;
        public event Action BackToMainMenuClick;
        
        private void Start() {
            AddListeners();
        }

        private void AddListeners() {
            _restartLevelButton.onClick.AddListener(RestartLevelButtonClick);
            _backToMainMenuButton.onClick.AddListener(BackToMainMenuButtonClick);
        }

        private void RestartLevelButtonClick() {
            Show(false);
            LevelRestartClick?.Invoke();
        }

        private void BackToMainMenuButtonClick() {
            BackToMainMenuClick?.Invoke();
        }

        public override void Dispose() {
            _restartLevelButton.onClick.RemoveListener(RestartLevelButtonClick);
            _backToMainMenuButton.onClick.RemoveListener(BackToMainMenuButtonClick);
        }
    }
}