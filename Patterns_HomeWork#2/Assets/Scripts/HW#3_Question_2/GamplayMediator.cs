public class GameplayMediator {
    private UIPanelsManager _uIPanelsManager;
    private Level _level;

    public Level Level => _level;

    public GameplayMediator(Level level, UIPanelsManager uIPanelsManager) {
        _level = level;

        _uIPanelsManager = uIPanelsManager;
        _uIPanelsManager.Init(this);

        _level.Defeat += OnLevelDefeat;
        _level.Victory += OnLevelVictory;
    }

    public void StartLevel() {
        _level.StartLevel();
        _uIPanelsManager.ShowGamePanel();
    }
    
    public void RestartLevel() {
        _level.Restart();
        StartLevel();
    }

    private void OnLevelDefeat() {
        _uIPanelsManager.ShowDefeatPanel();
    }

    private void OnLevelVictory() {
        _uIPanelsManager.ShowVictoryPanel();
    }

    private void OnDisable() {
        _level.Defeat -= OnLevelDefeat;
        _level.Victory -= OnLevelVictory;
    }
}
