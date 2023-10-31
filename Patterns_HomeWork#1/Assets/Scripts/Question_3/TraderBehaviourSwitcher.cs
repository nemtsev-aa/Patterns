using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TraderBehaviourSwitcher : MonoBehaviour {
    [SerializeField] private TradeStrategieConfig _noTrade, _fruitTrade, _armorTrade;
    private List<ITrader> _tradingStrategies;

    public void Init() {
        CreateStrategies();
    }
    
    private void CreateStrategies() {
        _tradingStrategies = new List<ITrader>();

        _tradingStrategies.Add(new NotTrade(GetConfig(TrageStrategieTypes.Not)));
        _tradingStrategies.Add(new FruitTrade(GetConfig(TrageStrategieTypes.Fruit)));
        _tradingStrategies.Add(new ArmorTrade(GetConfig(TrageStrategieTypes.Armor)));
    }

    private TradeStrategieConfig GetConfig(TrageStrategieTypes type) {
        TradeStrategieConfig config;
        
        switch (type) {
            case TrageStrategieTypes.Not:
                config = _noTrade;
                break;

            case TrageStrategieTypes.Fruit:
                config = _fruitTrade;
                break;

            case TrageStrategieTypes.Armor:
                config = _armorTrade;
                break;

            default:
                throw new ArgumentNullException($"Invalide TrageStrategieType {type}");
        }

        return config;
    }

    public ITrader GetStrategie(ITradable player) {
        return _tradingStrategies.Last(ts => ts.Config.Limit <= player.Reputation);
    }
}