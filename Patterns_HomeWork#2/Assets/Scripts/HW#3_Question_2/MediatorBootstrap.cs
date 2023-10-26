using System.Collections.Generic;
using UnityEngine;

public class MediatorBootstrap : MonoBehaviour {
    [SerializeField] private GameplayMediator _gameplayMediator;
    [SerializeField] private UIPanelsManager _uIPanelsManager;
    [SerializeField] private List<ObjectsSpawnerBase> _spawners;

    [Space(5)]
    [SerializeField] private Character _character;

    private Level _level;

    private void Awake() {
        _character.Init();
        _level = new Level(_character, _spawners);
        
        _gameplayMediator = new GameplayMediator(_level, _uIPanelsManager);
        _gameplayMediator.StartLevel();
    }
}
