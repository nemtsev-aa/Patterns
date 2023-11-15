using System;

public class CoinsCreateMediator : IDisposable {
    private readonly CreateCoinsPanel _coinsPanel;
    private readonly CoinSpawner _coinSpawner;

    public CoinsCreateMediator(CreateCoinsPanel coinsPanel, CoinSpawner coinSpawner) {
        _coinsPanel = coinsPanel;
        _coinsPanel.Init(this);

        _coinSpawner = coinSpawner;
        _coinSpawner.StartCreated += HidePanel;
        _coinSpawner.StopCreated += ShowPanel;

        ShowPanel();
    }

    public void CreateCoins() => _coinSpawner.StartWork();

    public void DestroyCoins() => _coinSpawner.Reset();

    public void Dispose() {
        _coinSpawner.StartCreated -= HidePanel;
        _coinSpawner.StopCreated -= ShowPanel;
    }

    private void ShowPanel() => _coinsPanel.Show();

    private void HidePanel() => _coinsPanel.Hide();
}