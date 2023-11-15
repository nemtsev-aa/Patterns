using UnityEngine;

public abstract class AbstractResourcesFactory {
    protected Sprite Coin;
    protected Sprite Energy;

    public AbstractResourcesFactory(Sprite coin, Sprite energy) { }
    public abstract BaseCoin GetCoin();
    public abstract BaseEnergy GetEnergy();
}