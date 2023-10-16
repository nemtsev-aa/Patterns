using UnityEngine;

public interface ITrader {
    ParticleSystem ParticleSystem { get; }
    string Sell();
}
