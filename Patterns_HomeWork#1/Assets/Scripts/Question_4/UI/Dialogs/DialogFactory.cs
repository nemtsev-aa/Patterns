using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogFactory : MonoBehaviour {
    private const string PrefabsFilePath = "Dialogs/";

    private static readonly Dictionary<Type, string> _prefabsDictionary = new Dictionary<Type, string>() {
            {typeof(StartMenuDialog),"StartMenuDialog"},
            {typeof(GameProcessDialog),"GameProcessDialog"},
            {typeof(VictoryDialog),"VictoryDialog"}
    };

    public T GetDialog<T>() where T : Dialog {
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
