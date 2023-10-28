public abstract class StateDecorator : Stats {
    protected Stats stats;

    public StateDecorator(Stats stats) : base(stats.Strength, stats.Intelligence, stats.Agility) {
        this.stats = stats;
    }
}
