using UnityEngine;

public interface ITrader {
    TradeStrategieConfig Config{ get; }
    string Sell();
}
