using UnityEngine;

public class BaseCoin {
    public BaseCoin(Sprite sprite) {
        Sprite = sprite;
    }

    [field: SerializeField] public Sprite Sprite { get; private set; }
}
