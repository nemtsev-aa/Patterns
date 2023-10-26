using System;
using UnityEngine;

[CreateAssetMenu(fileName = "UIPanelFactory", menuName = "Factory/UIPanelFactory")]
public class UIPanelFactory : ScriptableObject {
    [SerializeField] private UIPanelConfig _game, _defeat, _victory;
    
    public UIPanel Get(UIPanelType type, RectTransform parent) {
        UIPanelConfig config = GetConfig(type);
        UIPanel instance = Instantiate(config.Prefab, parent);
        return instance;
    }

    private UIPanelConfig GetConfig(UIPanelType type) {
        switch (type) {
            case UIPanelType.Game:
                return _game;

            case UIPanelType.Defeat:
                return _defeat;

            case UIPanelType.Victory:
                return _victory;

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
