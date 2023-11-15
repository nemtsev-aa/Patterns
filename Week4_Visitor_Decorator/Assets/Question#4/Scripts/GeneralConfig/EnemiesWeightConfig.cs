using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesWeightConfig", menuName = "Configs/EnemiesWeightConfig")]
public class EnemiesWeightConfig : ScriptableObject {
    [SerializeField] private int _ork;
    [SerializeField] private int _human;
    [SerializeField] private int _elf;
    [SerializeField] private int _robot;
    [SerializeField] private int _dwarf;

    public int Ork => _ork;
    public int Human => _human;
    public int Elf => _elf;
    public int Robot => _robot;
    public int Dwarf => _dwarf;
}
