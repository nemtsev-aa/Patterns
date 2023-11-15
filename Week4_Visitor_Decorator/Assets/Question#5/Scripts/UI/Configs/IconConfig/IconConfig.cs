using UnityEngine;
using System;

[Serializable]
public class IconConfig {
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public Sprite Frame { get; private set; }
}
