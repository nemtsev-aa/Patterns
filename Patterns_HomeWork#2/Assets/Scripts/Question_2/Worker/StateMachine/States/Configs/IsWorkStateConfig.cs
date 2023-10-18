using System;
using UnityEngine;

[Serializable]
public class IsWorkStateConfig {
    [SerializeField, Range(1, 20)] private float _time;

    public float Time => _time;
}

