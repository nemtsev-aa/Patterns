using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectsSpawnerBase : MonoBehaviour {
    [SerializeField] protected List<Transform> SpawnPoints;

    protected Coroutine Spawn;
    protected Level Level;

    [field: SerializeField] public float SpawnCooldown { get; private set; }
    
    public void Init(Level level) {
        Level = level;

        Level.OnStart += StartWork;
        Level.OnRestart += Reset;
    }

    protected virtual void StartWork() {
        if (SpawnPoints.Count == 0) {
            throw new ArgumentOutOfRangeException($"Invalid SpawnPoints count: {SpawnPoints}");
        }

        StopWork();

        Spawn = StartCoroutine(SpawnObjects());
    }

    protected virtual void StopWork() {
        if (Spawn != null)
            StopCoroutine(Spawn);
    }

    public abstract void Reset();

    public abstract IEnumerator SpawnObjects();

    protected virtual void OnDisable() {
        Level.OnStart -= StartWork;
        Level.OnRestart -= Reset;
    }
}
