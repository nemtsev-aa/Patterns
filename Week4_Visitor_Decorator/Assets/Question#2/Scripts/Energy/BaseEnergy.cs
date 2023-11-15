using UnityEngine;

public class BaseEnergy {
    public BaseEnergy(Sprite sprite) {
        Sprite = sprite;
    }

    [field: SerializeField] public Sprite Sprite { get; private set; }
}