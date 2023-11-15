using UnityEngine;

public class GameResourcesFactory : AbstractResourcesFactory {
    public GameResourcesFactory(Sprite coin, Sprite energy) : base(coin, energy) {
        Coin = coin;
        Energy = energy;
    }

    public override BaseCoin GetCoin() {
        return new GameCoin(Coin);
    }

    public override BaseEnergy GetEnergy() {
        return new GameEnergy(Energy);
    }
}