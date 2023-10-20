using System;
using UnityEngine;

[Serializable]
public class RunningStateConfig
{
    [SerializeField, Range(0, 5)] private float _slowSpeed;
    [SerializeField, Range(6, 10)] private float _speed;
    [SerializeField, Range(11, 20)] private float _fastSpeed;

    public float SlowSpeed => _slowSpeed;
    public float Speed => _speed;
    public float FastSpeed => _fastSpeed;
}
