using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DialogManager : MonoBehaviour {
    private const string PrefabsFilePath = "Dialogs/";

    private List<Dialog> _dialogs = new List<Dialog>();
    private static readonly Dictionary<Type, string> _prefabsDictionary = new Dictionary<Type, string>() {
            {typeof(StartMenuDialog),"StartMenuDialog"},
            {typeof(GameProcessDialog),"GameProcessDialog"},
            {typeof(VictoryDialog),"VictoryDialog"}
    };
    private Dialog _activeDialog;

    public void Init() {
        _dialogs.Add(CreateDialog<StartMenuDialog>());
        _dialogs.Add(CreateDialog<GameProcessDialog>());
        _dialogs.Add(CreateDialog<VictoryDialog>());

        foreach (var iDialog in _dialogs) {
            iDialog.gameObject.SetActive(false);
        }
    }

    public void ShowDialog<T>() {
        if (_activeDialog != null) _activeDialog.Show(false);
        _activeDialog = _dialogs.FirstOrDefault(dialog => dialog is T);
        _activeDialog.Show(true);
    }

    public T GetDialogByType<T>() where T : Dialog {
        return (T)_dialogs.FirstOrDefault(dialog => dialog is T);
    }
    
    private T CreateDialog<T>() where T : Dialog {
        var go = GetPrefabByType<T>();
        
        if (go == null) return null;
   
        return Instantiate(go, transform);
    }

    private T GetPrefabByType<T>() where T : Dialog {
        var prefabName = _prefabsDictionary[typeof(T)];

        if (string.IsNullOrEmpty(prefabName)) {
            Debug.LogError("Cant find prefab type of " + typeof(T) + "Do you added it in PrefabsDictionary?");
        }

        var path = PrefabsFilePath + _prefabsDictionary[typeof(T)];
        var dialog = Resources.Load<T>(path);

        if (dialog == null) Debug.LogError("Cant find prefab at path " + path);
        return dialog;
    }
}

