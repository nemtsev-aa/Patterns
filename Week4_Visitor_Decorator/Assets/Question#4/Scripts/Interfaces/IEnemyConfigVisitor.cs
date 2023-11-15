public interface IEnemyConfigVisitor {
    void Visit(EnemyConfig enemy);
    void Visit(OrkConfig ork);
    void Visit(HumanConfig human);
    void Visit(ElfConfig elf);
    void Visit(RobotConfig robot);
    void Visit(DwarfConfig dwarf);
}