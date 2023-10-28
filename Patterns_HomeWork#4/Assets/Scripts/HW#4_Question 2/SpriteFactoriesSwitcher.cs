using System;
using UnityEngine;

public class SpriteFactoriesSwitcher : MonoBehaviour {
    [SerializeField] private SpriteConfig _gameConfig, _shopConfig;

    public void ActivatePanel(ExecutionStyleType type, out Sprite coinIcon, out Sprite energyIcon) {
        SpriteFactory factory;
        switch (type) {
            case ExecutionStyleType.Game:
                factory = new GameSpriteFactory(_gameConfig);
                break;

            case ExecutionStyleType.Shop:
                factory = new ShopSpriteFactory(_shopConfig);
                break;

            default:
                throw new InvalidOperationException();
        }

        coinIcon = factory.Get(IconType.Coin);
        energyIcon = factory.Get(IconType.Energy);
    }
}
