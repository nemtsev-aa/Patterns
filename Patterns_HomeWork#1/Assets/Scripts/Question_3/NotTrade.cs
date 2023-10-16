using UnityEngine;

public class NotTrade : ITrader {
    public ParticleSystem ParticleSystem { get; set; }

    public NotTrade(ParticleSystem particleSystem) {
        ParticleSystem = particleSystem;
    }

    public string Sell() {
        return $"Не торгую";
    }
}
