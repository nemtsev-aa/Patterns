using Assets.Visitor;

public class EnemyPrefabVisitor : IEnemyConfigVisitor {
    public Enemy Prefab { get; private set; }

    public void Visit(EnemyConfig config) => Visit((dynamic)config);

    public void Visit(OrkConfig ork) => Prefab = ork.Prefab;

    public void Visit(HumanConfig human) => Prefab = human.Prefab;

    public void Visit(ElfConfig elf) => Prefab = elf.Prefab;

    public void Visit(RobotConfig robot) => Prefab = robot.Prefab;

    public void Visit(DwarfConfig dwarf) => Prefab = dwarf.Prefab;
}