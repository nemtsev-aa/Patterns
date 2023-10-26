using System;
using UnityEngine;

[Serializable]
public class ObjectConfig {
    [SerializeField] protected int _value;
    [SerializeField] protected float _timeDuration;

    public int Value => _value;
    public float TimeDuartion => _timeDuration;
}
