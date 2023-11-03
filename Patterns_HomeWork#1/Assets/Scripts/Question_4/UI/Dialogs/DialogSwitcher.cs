using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogSwitcher : MonoBehaviour {
    [SerializeField] private DialogFactory _dialogFactory;
    private List<Dialog> _dialogs;
    private Dialog _activeDialog;

    public void Init() { 
        CreateDialogs();
    }

    public void ShowDialog<T>() {
        if (_activeDialog != null) _activeDialog.Show(false);
        _activeDialog = _dialogs.FirstOrDefault(dialog => dialog is T);
        _activeDialog.Show(true);
    }

    public T GetDialogByType<T>() where T : Dialog {
        return (T)_dialogs.FirstOrDefault(dialog => dialog is T);
    }

    private void CreateDialogs() {
        _dialogs = new List<Dialog>();

        _dialogs.Add(_dialogFactory.GetDialog<StartMenuDialog>());
        _dialogs.Add(_dialogFactory.GetDialog<GameProcessDialog>());
        _dialogs.Add(_dialogFactory.GetDialog<VictoryDialog>());

        foreach (var iDialog in _dialogs) {
            iDialog.gameObject.SetActive(false);
        }
    }
}