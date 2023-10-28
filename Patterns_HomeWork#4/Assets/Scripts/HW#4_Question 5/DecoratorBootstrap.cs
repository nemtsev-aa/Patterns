using UnityEngine;

public class DecoratorBootstrap : MonoBehaviour {
    [SerializeField] private Race _race;
    [SerializeField] private Specialization _spec;
    [SerializeField] private PassiveAbility _passiveAbility;
    [SerializeField] private DecoratorConfigs _decoratorConfigs;

    [ContextMenu("CreateCharacter")]
    public void CreateCharacter() {
        // ������� ��������� � ���������� ����������������
        Character character = new Character(_race, _spec, _passiveAbility, _decoratorConfigs);

        // ������� �������������� ���������
        Debug.Log($"Race: {_race}, Spec: {_spec}, PassiveAbility: {_passiveAbility}");
        Debug.Log("Strength: " + character.Stats.Strength);
        Debug.Log("Intelligence: " + character.Stats.Intelligence);
        Debug.Log("Agility: " + character.Stats.Agility);
        Debug.Log($"--------------");
    }
}
