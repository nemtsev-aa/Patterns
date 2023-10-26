using System;
using System.Collections.Generic;

public class Level {
    private Character _character;
    private IEnumerable<ObjectsSpawnerBase> _spawners;
    
    public Character Character => _character;

    public Level(Character character, IEnumerable<ObjectsSpawnerBase> spawners) {
        _character = character;
        _character.Health.HealthIsOver += OnDefeat;
        _character.ExperienceCounter.MaxLevelReached += OnVictory;
        
        _spawners = spawners;
        foreach (var iSpawner in _spawners) {
            iSpawner.Init(this);
        }
    }

    public event Action OnStart;
    public event Action Defeat;
    public event Action Victory;
    public event Action OnRestart;

    public void StartLevel() {
        OnStart?.Invoke();
    }

    public void Restart() {
        _character.Reset();
        OnRestart?.Invoke();
       
        StartLevel();
    }

    private void OnDefeat() {
        Defeat?.Invoke();
    }

    private void OnVictory() {
        Victory?.Invoke();
    }

    private void OnDisable() {
        _character.Health.HealthIsOver -= OnDefeat;
        _character.ExperienceCounter.MaxLevelReached -= OnVictory;
    }
}
