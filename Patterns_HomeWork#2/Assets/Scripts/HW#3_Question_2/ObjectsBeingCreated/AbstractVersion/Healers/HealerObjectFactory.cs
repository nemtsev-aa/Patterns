using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HealerObjectFactory", menuName = "AbstractFactory/HealerObjectFactory")]
public class HealerObjectFactory : ObjectTypeFactory {
    [SerializeField] private HealerConfig _small, _medium, _large;
    
    public override ObjectSize Get(ObjectSizeType type) {
        switch (type) {
            case ObjectSizeType.Small:
                return new SmallHealerObject(_small);

            case ObjectSizeType.Medium:
                return new MediumHealerObject(_medium);

            case ObjectSizeType.Large:
                return new LargeHealerObject(_large);

            default:
                throw new ArgumentException(nameof(type));
        }
    }
}