using Assets.Visitor;
using System;
using UnityEngine;

public abstract class EnemyConfig : ScriptableObject {
    [SerializeField] protected Enemy EnemyPrefab;
    [SerializeField, Range(1, 10)] protected int EnemyHealth;
    [SerializeField, Range(1, 10)] protected float EnemySpeed;

    public Enemy Prefab => EnemyPrefab;
    public int Health => EnemyHealth;
    public float Speed => EnemySpeed;
}