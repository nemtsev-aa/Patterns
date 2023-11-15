public abstract class StatsDecorator : IStatsProvider {
    protected readonly IStatsProvider _wrappedEntity;

    protected StatsDecorator(IStatsProvider wrappedEntity) {
        _wrappedEntity = wrappedEntity;
    }

    public CharacterStats GetStats() {
        return GetStatsInternal();
    }

    protected abstract CharacterStats GetStatsInternal();
}
