using UnityEngine;

public class DecoratorBootstrap : MonoBehaviour {
    [SerializeField] private Races _race;
    [SerializeField] private Specializations _spec;
    [SerializeField] private PassiveAbilitys _passiveAbility;
    [SerializeField] private DecoratorConfigs _decoratorConfigs;

    [ContextMenu("CreateCharacter")]
    public void CreateCharacter() {
        Character character = new Character(_race, _spec, _passiveAbility, _decoratorConfigs);

        CharacterStats stats = character.Provider.GetStats();

        Debug.Log($"Race: {_race}, Spec: {_spec}, PassiveAbility: {_passiveAbility}");
        Debug.Log("Strength: " + stats.Strength);
        Debug.Log("Intelligence: " + stats.Intelligence);
        Debug.Log("Agility: " + stats.Agility);
        Debug.Log($"--------------");
    }
}
