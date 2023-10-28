using UnityEngine;

public class GameSpriteFactory : SpriteFactory {
    public GameSpriteFactory(SpriteConfig config) : base(config) {
    }

    public override Sprite Get(IconType type) {
        return base.Get(type);
    }
}