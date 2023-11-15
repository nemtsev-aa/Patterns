using UnityEngine;
using System;

[Serializable]
public class RaceIconConfig : IconConfig {
    [field: SerializeField] public Races Race { get; private set; }
}
