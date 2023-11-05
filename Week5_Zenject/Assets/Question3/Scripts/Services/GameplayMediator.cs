using UnityEngine;
using Zenject;

namespace Question3 {
    public class GameplayMediator : MonoBehaviour {
        private ISceneLoadMediator _sceneLoader;
        private DialogSwitcher _dialogSwitcher;
        private VictoryConditionSwitcher _victoryConditionSwitcher;
                
        private Level _level;
        private VictoryCondition _victoryCondition;
        private VictoryDialog _victoryDialog;

        [Inject]
        private void Construct(ISceneLoadMediator sceneLoadMediator, DialogSwitcher dialogSwitcher, Level level, VictoryConditionSwitcher victoryConditionSwitcher) {
            _sceneLoader = sceneLoadMediator;
            _dialogSwitcher = dialogSwitcher;
            _victoryConditionSwitcher = victoryConditionSwitcher;
            
            _level = level;

            AddSubscribers();
            PrepareLevel();
        }

        private void AddSubscribers() {
            _level.Prepared += StartLevel;

            _victoryDialog = _dialogSwitcher.GetDialogByType<VictoryDialog>();
            _victoryDialog.OnClosed += ApplicationQuit;
            _victoryDialog.LevelRestartClick += OnLevelRestart;
            _victoryDialog.BackToMainMenuClick += ShowStartMenu;
        }

        private void PrepareLevel() {
            ShowGameProcessDialog();
            _level.SpawnSpheres();
        } 
 
        private void StartLevel() => SetVictoryCondition();

        private void SetVictoryCondition() {
            _victoryCondition = _victoryConditionSwitcher.GetVictoryCondition();
            _victoryCondition.Complited += OnLevelComplited;
        }

        private void OnLevelRestart() => PrepareLevel();

        private void ShowStartMenu() => _sceneLoader.GoToMainMenu();

        private void ApplicationQuit() => Application.Quit();

        private void ShowGameProcessDialog() => _dialogSwitcher.ShowDialog<GameProcessDialog>(); 

        private void ShowVictoryDialog() => _dialogSwitcher.ShowDialog<VictoryDialog>();

        private void OnLevelComplited() {
            if (_victoryCondition == null)
                return;

            ClearingVariables();
            ShowVictoryDialog();
        }

        private void ClearingVariables() {
            _victoryCondition.Complited -= OnLevelComplited;
            _victoryCondition = null;

            _level.ClearSpheres();
        }

        private void OnDisable() {
            _victoryDialog.OnClosed -= ApplicationQuit;
            _victoryDialog.LevelRestartClick -= OnLevelRestart;
            _victoryDialog.BackToMainMenuClick -= ShowStartMenu;
        }
    }
}