using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletFactory", menuName = "Factory/BulletFactory")]
public class BulletFactory : ScriptableObject {
    [SerializeField] private BulletConfig _small, _medium, _large;
    
    public Bullet Get(BulletTypes type) {
        BulletConfig config = GetConfig(type);
        Bullet newBullet = Instantiate(config.Prefab);
        newBullet.Init(config);        
        return newBullet;
    }

    private BulletConfig GetConfig(BulletTypes type) {
        switch (type) {
            case BulletTypes.Small:
                return _small;

            case BulletTypes.Medium:
                return _medium;

            case BulletTypes.Large:
                return _large;

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}
