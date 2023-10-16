using UnityEngine;

public class ApplicationManager : MonoBehaviour {
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private LevelManager _levelManager;

    private VictoryCondition _victory;
    
    private void Start() {
        Init();
    }

    private void Init() {
        _dialogManager.Init();
        CreateSubscribes();
        ShowStartMenu();
    }

    private void CreateSubscribes() {
        StartMenuDialog startMenuDialog = _dialogManager.GetDialogByType<StartMenuDialog>();
        GameProcessDialog gameProcessDialog = _dialogManager.GetDialogByType<GameProcessDialog>();
        VictoryDialog victoryDialog = _dialogManager.GetDialogByType<VictoryDialog>();

        startMenuDialog.SphereVariantView.Init(_levelManager.SphereCraetor.SpherePrefabs);
        startMenuDialog.OnConditionSelected += SetVictoryCondition;
        startMenuDialog.OnConditionSelected += gameProcessDialog.SetVictoryCondition;

        startMenuDialog.OnClosed += ApplicationQuit;
        gameProcessDialog.OnClosed += ApplicationRestert;
        victoryDialog.OnClosed += ApplicationRestert;
    }

    private void SetVictoryCondition(VictoryCondition victory) {
        _victory = victory;
        victory.Complited += LevelComplited;
        
        StartLevel();
    }

    private void ShowStartMenu() {
        _dialogManager.ShowDialog<StartMenuDialog>();
    }

    private void StartLevel() {
        _levelManager.Init(_victory);
        _dialogManager.ShowDialog<GameProcessDialog>();
    }

    private void ApplicationRestert() {
        _levelManager.Restart();
        ShowStartMenu();
    }

    private void LevelComplited() {
        _dialogManager.ShowDialog<VictoryDialog>();
    }

    private void ApplicationQuit() {
        Application.Quit();
    }
}
