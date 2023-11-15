public interface ICompanentVisitor {
    void Visit(UICompanentConfig companent);
    void Visit(PanelViewConfig panel);
    void Visit(SelectorViewConfig selector);
    void Visit(StatViewConfig stat);
}
