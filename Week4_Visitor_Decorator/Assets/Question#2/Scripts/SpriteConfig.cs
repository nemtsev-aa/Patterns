using UnityEngine;

[CreateAssetMenu(fileName = "SpriteConfig", menuName = "Configs/SpriteConfig")]
public class SpriteConfig : ScriptableObject {
    [SerializeField] private Sprite _gameCoinSprite;
    [SerializeField] private Sprite _gameEnergySprite;
    [Space(10)]
    [SerializeField] private Sprite _shopCoinSprite;
    [SerializeField] private Sprite _shopEnergySprite;
    [Space(10)]
    [SerializeField] private Sprite _winCoinSprite;
    [SerializeField] private Sprite _winEnergySprite;

    public Sprite GameCoinSprite => _gameCoinSprite;
    public Sprite GameEnergySprite => _gameEnergySprite;
    public Sprite ShopCoinSprite => _shopCoinSprite;
    public Sprite ShopEnergySprite => _shopEnergySprite;
    public Sprite WinCoinSprite => _winCoinSprite;
    public Sprite WinEnergySprite => _winEnergySprite;
}
