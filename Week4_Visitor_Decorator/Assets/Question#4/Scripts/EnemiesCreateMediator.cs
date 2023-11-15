
public class EnemiesCreateMediator {
    private readonly CreateEnemiesPanel _panel;
    private readonly EnemySpawner _enemySpawner;

    public EnemiesCreateMediator(CreateEnemiesPanel enemiesPanel, EnemySpawner enemySpawner, int maxWeightLimit) {
        _panel = enemiesPanel;
        _panel.Init(this, maxWeightLimit);

        _enemySpawner = enemySpawner;

        CreateSubscribes();
        ShowPanel();
    }

    public void CreateEnemies(int maxWeight) => _enemySpawner.StartWork(maxWeight);

    public void DestroyEnemies() => _enemySpawner.Reset();

    private void ShowPanel() => _panel.Show();

    private void HidePanel() => _panel.Hide();

    private void CreateSubscribes() {
        _panel.RandomEnemyKilled += RandomEnemyKill;
       
        _enemySpawner.StartCreated += HidePanel;
        _enemySpawner.WeightFixed += UpdateWeight;
        _enemySpawner.StopCreated += ShowPanel;
    }

    private void UpdateWeight(int value) => _panel.UpdateWeightText(value);

    private void RandomEnemyKill() => _enemySpawner.KillRandomEnemy();

    public void Dispose() {
        _enemySpawner.StartCreated -= HidePanel;
        _enemySpawner.WeightFixed -= UpdateWeight;
        _enemySpawner.StopCreated -= ShowPanel;
    }
}
