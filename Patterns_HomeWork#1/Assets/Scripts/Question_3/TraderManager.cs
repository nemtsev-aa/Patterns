using System;
using UnityEngine;

public class TraderManager : MonoBehaviour {
    [SerializeField, Range(0, 100)] private int _noTradeLimit = 10;
    [SerializeField, Range(0, 100)] private int _frutTradeLimit = 50;
    [SerializeField, Range(0, 100)] private int _armorTradeLimit = 100;

    [SerializeField] private Trader _traiderPrefab;
    [SerializeField] private Transform _traderPosition;
    
    private void OnValidate() {
        if (_frutTradeLimit <= _noTradeLimit) _frutTradeLimit = _noTradeLimit + 1;
        if (_armorTradeLimit <= _frutTradeLimit) _armorTradeLimit = _frutTradeLimit + 1;
    }

    private void Start() {
        if (_traderPosition == null) { 
            Debug.LogError("Точка раположения Торговцева не задана");
            return;
        }
        CreationTrader();
    }

    private void CreationTrader() {
        Trader newTrader = Instantiate(_traiderPrefab, _traderPosition.position, _traderPosition.rotation);
        int[] limitValues = new int[] { _noTradeLimit, _frutTradeLimit, _armorTradeLimit };
        newTrader.Init(limitValues);
    }
}
