using UnityEngine;

[CreateAssetMenu(fileName = "ObjectSize", menuName = "AbstractFactory/ObjectSize")]
public abstract class ObjectSize : ScriptableObject {
    public abstract GameObject CreateObject();
}
