using System;
using System.Collections.Generic;

public class EnemyWeightVisitor : IEnemyConfigVisitor {
    private readonly Dictionary<Type, int> _weightDictionary;

    public EnemyWeightVisitor(EnemiesWeightConfig weightConfig) {
        _weightDictionary = new Dictionary<Type, int>() {
            {typeof(OrkConfig), weightConfig.Ork },
            {typeof(HumanConfig), weightConfig.Human },
            {typeof(ElfConfig), weightConfig.Elf },
            {typeof(RobotConfig), weightConfig.Robot },
            {typeof(DwarfConfig), weightConfig.Dwarf }
        };
    }

    public int Weight { get; private set; }

    public void Visit(EnemyConfig enemy) => Visit((dynamic)enemy);

    public void Visit(OrkConfig ork) => Weight += _weightDictionary[typeof(OrkConfig)];

    public void Visit(HumanConfig human) => Weight += _weightDictionary[typeof(HumanConfig)];

    public void Visit(ElfConfig elf) => Weight += _weightDictionary[typeof(ElfConfig)];

    public void Visit(RobotConfig robot) => Weight += _weightDictionary[typeof(RobotConfig)];

    public void Visit(DwarfConfig dwarf) => Weight += _weightDictionary[typeof(DwarfConfig)];

    public void Reset() => Weight = 0;

}