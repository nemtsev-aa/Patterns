using UnityEngine;

public class ShopSpriteFactory : SpriteFactory {
    public ShopSpriteFactory(SpriteConfig config) : base(config) {
    }

    public override Sprite Get(IconType type) {
        return base.Get(type);
    }
}