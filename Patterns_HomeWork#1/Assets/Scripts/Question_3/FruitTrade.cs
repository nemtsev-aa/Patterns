using UnityEngine;

public class FruitTrade : ITrader {
    public ParticleSystem ParticleSystem { get; set; }

    public FruitTrade(ParticleSystem particleSystem) {
        ParticleSystem = particleSystem;
    }

    public string Sell() {
        return $"Продаю фрукты!";
    }
}

