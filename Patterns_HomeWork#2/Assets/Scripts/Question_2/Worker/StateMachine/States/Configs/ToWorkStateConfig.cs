using System;
using UnityEngine;

[Serializable]
public class ToWorkStateConfig {
    [SerializeField] private Transform _workPoint;

    public Transform WorkPoint => _workPoint;
}
