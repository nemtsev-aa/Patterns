using UnityEngine;

public class ShopResourcesFactory : AbstractResourcesFactory {
    public ShopResourcesFactory(Sprite coin, Sprite energy) : base(coin, energy) {
        Coin = coin;
        Energy = energy;
    }

    public override BaseCoin GetCoin() {
        return new ShopCoin(Coin);
    }

    public override BaseEnergy GetEnergy() {
        return new ShopEnergy(Energy);
    }
}