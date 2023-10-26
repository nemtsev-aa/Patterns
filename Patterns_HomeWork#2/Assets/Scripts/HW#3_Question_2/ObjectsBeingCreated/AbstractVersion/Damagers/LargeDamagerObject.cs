using UnityEngine;

public class LargeDamagerObject : DamagerObjectBase {
    public LargeDamagerObject(DamagerConfig objectConfig) : base(objectConfig) {
    }

    public override GameObject CreateObject() {
        base.CreateObject();

        Debug.Log("Создан LargeDamagerObject");
        return Trigger;
    }
}
