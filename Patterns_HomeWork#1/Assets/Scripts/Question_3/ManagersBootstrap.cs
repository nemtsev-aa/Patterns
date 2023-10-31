using System;
using UnityEngine;

public class ManagersBootstrap : MonoBehaviour {
    [SerializeField] private PlayerCharacter _player;
    [SerializeField] private Controller _controller;

    [SerializeField] private Trader _traiderPrefab;
    [SerializeField] private Transform _traderPosition;
    [SerializeField] private TraderBehaviourSwitcher _tradeStrategySwitcher;

    private void Start() {
        _player.Init(_controller);

        CreationTrader();
    }

    private void CreationTrader() {
        if (_traderPosition == null)
            throw new ArgumentNullException($"TraderPosition not find");

        _tradeStrategySwitcher.Init();

        Trader newTrader = Instantiate(_traiderPrefab, _traderPosition.position, _traderPosition.rotation);
        newTrader.Init(_tradeStrategySwitcher);
    }
}
