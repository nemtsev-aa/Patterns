using System;

public class DialogSubscriber : IDisposable {
    private ApplicationMediator _applicationManager;
    private DialogSwitcher _dialogSwitcher;

    private StartMenuDialog _startMenuDialog;
    private GameProcessDialog _gameProcessDialog;
    private VictoryDialog _victoryDialog;

    public DialogSubscriber(ApplicationMediator applicationManager, DialogSwitcher dialogSwitcher) {
        _applicationManager = applicationManager;
        _dialogSwitcher = dialogSwitcher;

        CreateSubscribes();
    }

    private void CreateSubscribes() {
        _startMenuDialog = _dialogSwitcher.GetDialogByType<StartMenuDialog>();
        _gameProcessDialog = _dialogSwitcher.GetDialogByType<GameProcessDialog>();
        _victoryDialog = _dialogSwitcher.GetDialogByType<VictoryDialog>();

        _startMenuDialog.Init(_applicationManager.SpheresSpawner.SpheresPrefabs);
        _startMenuDialog.AllColorVictoryConditionSelected += _applicationManager.SetAllColorVictoryConditionType;
        _startMenuDialog.SameColorVictoryConditionSelected += _applicationManager.SetSameColorVictoryConditionType;

        _startMenuDialog.AllColorVictoryConditionSelected += _gameProcessDialog.SetAllColorVictoryCondition;
        _startMenuDialog.SameColorVictoryConditionSelected += _gameProcessDialog.SetSameColorVictoryCondition;

        _startMenuDialog.OnClosed += _applicationManager.ApplicationQuit;
        _gameProcessDialog.OnClosed += _applicationManager.ApplicationRestert;
        _victoryDialog.OnClosed += _applicationManager.ApplicationRestert;
    }

    public void Dispose() {
        _startMenuDialog.AllColorVictoryConditionSelected += _applicationManager.SetAllColorVictoryConditionType;
        _startMenuDialog.SameColorVictoryConditionSelected += _applicationManager.SetSameColorVictoryConditionType;

        _startMenuDialog.OnClosed -= _applicationManager.ApplicationQuit;
        _gameProcessDialog.OnClosed -= _applicationManager.ApplicationRestert;
        _victoryDialog.OnClosed -= _applicationManager.ApplicationRestert;
    }
}
