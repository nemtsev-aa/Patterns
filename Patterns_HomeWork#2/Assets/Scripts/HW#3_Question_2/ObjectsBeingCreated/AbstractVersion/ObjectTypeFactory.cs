using UnityEngine;

public abstract class ObjectTypeFactory : ScriptableObject {
    public abstract ObjectSize Get(ObjectSizeType type);
}
