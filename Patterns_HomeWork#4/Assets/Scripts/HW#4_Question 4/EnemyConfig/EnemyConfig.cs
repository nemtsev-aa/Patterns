using Assets.Visitor;
using System;
using UnityEngine;

public abstract class EnemyConfig : ScriptableObject {
    [SerializeField] protected Enemy _prefab;
    [SerializeField, Range(1, 10)] protected int _health;
    [SerializeField, Range(1, 10)] protected float _speed;

    public Enemy Prefab => _prefab;
    public int Health => _health;
    public float Speed => _speed;
}