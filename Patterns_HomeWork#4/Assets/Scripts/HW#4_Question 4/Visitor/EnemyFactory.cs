﻿using System;
using UnityEngine;
using Assets.Visitor;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factory/EnemyFactory")]
public class EnemyFactory : ScriptableObject {
    [SerializeField] private Human _humanPrefab;
    [SerializeField] private Ork _orkPrefab;
    [SerializeField] private Elf _elfPrefab;
    [SerializeField] private Robot _robotPrefab;
    [SerializeField] private Dwarf _dwarfPrefab;

    public Enemy Get(EnemyType type) {
        switch (type) {
            case EnemyType.Elf:
                return Instantiate(_elfPrefab);

            case EnemyType.Human:
                return Instantiate(_humanPrefab);

            case EnemyType.Ork:
                return Instantiate(_orkPrefab);

            case EnemyType.Robot:
                return Instantiate(_robotPrefab);

            case EnemyType.Dwarf:
                return Instantiate(_dwarfPrefab);
            
            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
