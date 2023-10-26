using UnityEngine;

public class MediumHealerObject : HealerObjectBase {
    public MediumHealerObject(HealerConfig objectConfig) : base(objectConfig) {
    }

    public override GameObject CreateObject() {
        base.CreateObject();

        Debug.Log("Создан MediumHealerObject");
        return Trigger;
    }
}