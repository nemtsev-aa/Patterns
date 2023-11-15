using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyFactory", menuName = "Factory/EnemyFactory")]
public class EnemyFactory : ScriptableObject {
    private EnemyPrefabVisitor _prefabVisitor;
    
    private Enemy Prefab => _prefabVisitor.Prefab;
    
    public void Init() {
        _prefabVisitor = new EnemyPrefabVisitor();
    }

    public Enemy Get(EnemyConfig config) {
        if (_prefabVisitor == null) 
            throw new ArgumentNullException($"VisitorEnemyFactory not initialized!");

        _prefabVisitor.Visit(config);
        return Instantiate(Prefab);
    }
}
