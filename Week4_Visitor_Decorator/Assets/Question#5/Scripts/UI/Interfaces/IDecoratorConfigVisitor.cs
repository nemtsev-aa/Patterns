public interface IDecoratorConfigVisitor {
    void Visit(DecoratorConfig config);
    void Visit(RaceDecoratorConfig race);
    void Visit(SpecializationDecoratorConfig specialization);
    void Visit(PassiveAbilityDecoratorConfig passiveAbility);
}
