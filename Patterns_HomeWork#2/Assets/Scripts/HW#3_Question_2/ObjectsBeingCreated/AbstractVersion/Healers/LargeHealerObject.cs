using UnityEngine;

public class LargeHealerObject : HealerObjectBase {
    public LargeHealerObject(HealerConfig objectConfig) : base(objectConfig) {
    }

    public override GameObject CreateObject() {
        base.CreateObject();

        Debug.Log("Создан LargeHealerObject");
        return Trigger;
    }
}
