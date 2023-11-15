using UnityEngine;

public class WinResourcesFactory : AbstractResourcesFactory {
    public WinResourcesFactory(Sprite coin, Sprite energy) : base(coin, energy) {
        Coin = coin;
        Energy = energy;
    }

    public override BaseCoin GetCoin() {
        return new WinCoin(Coin);
    }

    public override BaseEnergy GetEnergy() {
        return new WinEnergy(Energy);
    }
}
