using System;
using UnityEngine;

[Serializable]
public class BulletConfig {
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _lifeTime = 5f;

    public Bullet Prefab => _prefab;
    public float Speed => _speed;
    public int Damage => _damage;
    public float LifeTime => _lifeTime;
}
