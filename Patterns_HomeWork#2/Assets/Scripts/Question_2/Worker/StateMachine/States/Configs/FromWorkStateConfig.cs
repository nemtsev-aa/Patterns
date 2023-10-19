using System;
using UnityEngine;

[Serializable]
public class FromWorkStateConfig {
    [SerializeField] private Transform _relaxingPoint;

    public Transform RelaxingPoint => _relaxingPoint;
}
