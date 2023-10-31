public class FruitTrade : ITrader {
    public TradeStrategieConfig Config { get; set; }

    public FruitTrade(TradeStrategieConfig config) {
        Config = config;
    }

    public string Sell() {
        return $"Продаю фрукты!";
    }
}

