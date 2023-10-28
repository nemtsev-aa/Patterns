using UnityEngine;

public abstract class SpriteFactory {
    public SpriteConfig Config { get; private set; }

    public SpriteFactory(SpriteConfig config) {
        Config = config;
    }

    public virtual Sprite Get(IconType type) {
        Sprite sprite;

        if (type == IconType.Coin)
            sprite = Config.CoinSprite;
        else
            sprite = Config.EnergySprite;

        return sprite;
    }
}