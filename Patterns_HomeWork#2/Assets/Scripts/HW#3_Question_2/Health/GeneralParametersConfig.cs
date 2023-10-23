using System;
using UnityEngine;

[Serializable]
public class GeneralParametersConfig {
    [SerializeField, Range(0, 5)] private int _maxHealth;
    
    public int MaxHealth => _maxHealth;
}
