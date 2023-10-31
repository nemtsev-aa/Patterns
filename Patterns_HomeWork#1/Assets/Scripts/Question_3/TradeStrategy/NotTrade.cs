public class NotTrade : ITrader {
    public TradeStrategieConfig Config { get; set; }

    public NotTrade(TradeStrategieConfig config) {
        Config = config;
    }

    public string Sell() {
        return $"Не торгую";
    }
}
