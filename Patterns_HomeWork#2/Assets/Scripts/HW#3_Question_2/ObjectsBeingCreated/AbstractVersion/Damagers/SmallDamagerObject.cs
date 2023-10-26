using UnityEngine;

public class SmallDamagerObject : DamagerObjectBase {
    public SmallDamagerObject(DamagerConfig objectConfig) : base(objectConfig) {
    }

    public override GameObject CreateObject() {
        base.CreateObject();

        Debug.Log("Создан SmallDamagerObject");
        return Trigger;
    }
}
