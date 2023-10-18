using System;
using UnityEngine;

[Serializable]
public class ToWorkStateConfig {
    [SerializeField, Range(0.01f, 2f)] private float _speed;
    [SerializeField] private Transform _workPoint;

    public float Speed => _speed;
    public Transform WorkPoint => _workPoint;
}
