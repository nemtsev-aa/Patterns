using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Question3 {
    public class DialogFactory {
        private const string PrefabsFilePath = "Dialogs/";

        private static readonly Dictionary<Type, string> _prefabsDictionary = new Dictionary<Type, string>() {
            {typeof(StartMenuDialog),"StartMenuDialog"},
            {typeof(GameProcessDialog),"GameProcessDialog"},
            {typeof(VictoryDialog),"VictoryDialog"}
        };

        private DiContainer _container;

        public DialogFactory(DiContainer container) {
            _container = container;
        }

        public T GetDialog<T>(RectTransform parent) where T : Dialog {
            var go = GetPrefabByType<T>();

            if (go == null) 
                return null;

            return (T)_container.InstantiatePrefabForComponent<Dialog>(go, parent);
        }

        private T GetPrefabByType<T>() where T : Dialog {
            var prefabName = _prefabsDictionary[typeof(T)];

            if (string.IsNullOrEmpty(prefabName)) {
                Debug.LogError("Cant find prefab type of " + typeof(T) + "Do you added it in PrefabsDictionary?");
            }

            var path = PrefabsFilePath + _prefabsDictionary[typeof(T)];
            var dialog = Resources.Load<T>(path);

            if (dialog == null)
                Debug.LogError("Cant find prefab at path " + path);

            return dialog;
        }
    }
}