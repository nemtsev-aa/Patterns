using System;
using UnityEngine;

[Serializable]
public class TradeStrategieConfig {
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private int _limit;

    public ParticleSystem Particle => _particle;
    public int Limit => _limit;
}
