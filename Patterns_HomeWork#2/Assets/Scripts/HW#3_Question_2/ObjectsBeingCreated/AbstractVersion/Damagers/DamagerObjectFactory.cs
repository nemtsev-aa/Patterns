using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DamagerObjectFactory", menuName = "AbstractFactory/DamagerObjectFactory")]
public class DamagerObjectFactory : ObjectTypeFactory {
    [SerializeField] private DamagerConfig _small, _medium, _large;
    
    public override ObjectSize Get(ObjectSizeType type) {
        switch (type) {
            case ObjectSizeType.Small:
                return new SmallDamagerObject(_small);

            case ObjectSizeType.Medium:
                return new MediumDamagerObject(_medium);

            case ObjectSizeType.Large:
                return new LargeDamagerObject(_large);

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}


