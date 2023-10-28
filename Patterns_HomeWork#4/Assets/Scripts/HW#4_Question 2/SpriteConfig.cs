using System;
using UnityEngine;

[Serializable]
public class SpriteConfig {
    [SerializeField] protected Sprite Coin;
    [SerializeField] protected Sprite Energy;

    public Sprite CoinSprite => Coin;
    public Sprite EnergySprite => Energy;
}
