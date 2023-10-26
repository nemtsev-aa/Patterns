using UnityEngine;

public abstract class ObjectBase : ObjectSize {
    protected GameObject Trigger;

    public override GameObject CreateObject() {
        GetPrefab();
        SetEffect();

        return Trigger;
    }

    protected abstract void GetPrefab();
    protected abstract void SetEffect();
}