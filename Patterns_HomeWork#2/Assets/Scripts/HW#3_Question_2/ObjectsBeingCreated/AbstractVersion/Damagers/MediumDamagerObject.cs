using UnityEngine;

public class MediumDamagerObject : DamagerObjectBase {
    public MediumDamagerObject(DamagerConfig objectConfig) : base(objectConfig) {
    }

    public override GameObject CreateObject() {
        base.CreateObject();
        
        Debug.Log("Создан MediumDamagerObject");
        return Trigger;
    }
}