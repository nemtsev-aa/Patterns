using System;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public event Action<Enemy> Died;

    public EnemyConfig Config { get; private set; }

    public void Init(EnemyConfig config) {
        Config = config;
    }

    public void MoveTo(Vector3 position) => transform.position = position;

    public void Kill() {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}

