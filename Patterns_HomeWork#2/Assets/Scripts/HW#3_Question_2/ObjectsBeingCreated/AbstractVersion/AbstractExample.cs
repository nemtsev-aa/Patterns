using System;
using UnityEngine;

public class AbstractExample : MonoBehaviour {
    [SerializeField] private ObjectSizeType _objectSize;
    [SerializeField] private ObjectType _objectType;

    [SerializeField] private HealerObjectFactory _healerObjectFactory;
    [SerializeField] private DamagerObjectFactory _damagerObjectFactory;

    [SerializeField] private Transform _spawnPoint;

    [ContextMenu("CreateObject")]
    public void CreateObject() {
        ObjectTypeFactory factory;

        switch (_objectType) {
            case ObjectType.Healer:
                factory = _healerObjectFactory;
                break;

            case ObjectType.Damager:
                factory = _damagerObjectFactory;
                break;

            default:
                throw new InvalidOperationException();
        }

        GameObject newObject = factory.Get(_objectSize).CreateObject();
        newObject.transform.position = _spawnPoint.position;
    }
}