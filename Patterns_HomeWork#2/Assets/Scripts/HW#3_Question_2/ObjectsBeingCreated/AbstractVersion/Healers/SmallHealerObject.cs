using UnityEngine;

public class SmallHealerObject : HealerObjectBase {
    public SmallHealerObject(HealerConfig objectConfig) : base(objectConfig) {
    }

    public override GameObject CreateObject() {
        base.CreateObject();

        Debug.Log("Создан SmallHealerObject");
        return Trigger;
    }
}
