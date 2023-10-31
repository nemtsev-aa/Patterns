public class ArmorTrade : ITrader {
    public TradeStrategieConfig Config { get; set; }

    public ArmorTrade(TradeStrategieConfig config) {
        Config = config;
    }

    public string Sell() {
        return $"Продаю броню!";
    }
}
