using System;
using UnityEngine;

[Serializable]
public class FromWorkStateConfig {
    [SerializeField, Range(0.01f, 2f)] private float _speed;
    [SerializeField] private Transform _relaxingPoint;

    public float Speed => _speed;
    public Transform RelaxingPoint => _relaxingPoint;
}
