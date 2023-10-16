using UnityEngine;

public class ArmorTrade : ITrader {
    public ParticleSystem ParticleSystem { get; set; }
    
    public ArmorTrade(ParticleSystem particleSystem) {
        ParticleSystem = particleSystem;
    }

    public string Sell() {
        return $"Продаю броню!";
    }
}
