using System;
using UnityEngine;
using Zenject;

namespace Question2 {
    public class GameplayMediator : ITickable, IDisposable {
        private DefeatPanel _defeatPanel;
        private Level _level;

        public GameplayMediator(DefeatPanel defeatPanel, Level level) {
            _defeatPanel = defeatPanel;
            _level = level;

            _level.Defeat += OnLevelDefeat;

            Start();
        }

        private void Start() {
            _defeatPanel.Initialize(this);
            _level.Start();
        }

        public void Tick() {
            if (Input.GetKeyDown(KeyCode.Space))
                _level.OnDefeat();
        }

        public void Dispose() => _level.Defeat -= OnLevelDefeat;

        public void RestartLevel() {
            _defeatPanel.Hide();
            _level.Restart();
        }

        private void OnLevelDefeat() => _defeatPanel.Show();
    }
}