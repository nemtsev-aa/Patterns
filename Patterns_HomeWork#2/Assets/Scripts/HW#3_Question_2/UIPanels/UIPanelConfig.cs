using System;
using UnityEngine;

[Serializable]
public class UIPanelConfig {
    [SerializeField] private UIPanel _prefab;
    
    public UIPanel Prefab => _prefab;
}