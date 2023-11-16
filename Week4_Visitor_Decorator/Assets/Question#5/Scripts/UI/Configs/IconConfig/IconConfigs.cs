using System.Collections.Generic;
using UnityEngine;

public class IconConfigs : ScriptableObject {
    [Header("Races")]
    [SerializeField] private List<RaceIconConfig> _raceIcons;
    [Header("Specializations")]
    [SerializeField] private List<SpecializationIconConfig> _specializationIcons;
    [Header("PassiveAbility")]
    [SerializeField] private List<PassiveAbilityIconConfig> _passiveAbilityIcons;
}
