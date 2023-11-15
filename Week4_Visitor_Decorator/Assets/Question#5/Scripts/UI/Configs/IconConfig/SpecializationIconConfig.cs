using UnityEngine;
using System;

[Serializable]
public class SpecializationIconConfig : IconConfig {
    [field: SerializeField] public Specializations Specialization { get; private set; }
}
