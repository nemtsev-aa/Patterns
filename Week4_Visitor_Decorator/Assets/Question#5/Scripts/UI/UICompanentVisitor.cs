using System.Collections.Generic;
using System.Linq;

public class UICompanentVisitor : ICompanentVisitor {
    private IEnumerable<UICompanent> _companents;

    public UICompanentVisitor(IEnumerable<UICompanent> companents) {
        _companents = companents;
    }

    public UICompanent Companent { get; private set; }

    public void Visit(UICompanentConfig companent) => Visit((dynamic)companent);

    public void Visit(PanelViewConfig panel) => Companent = _companents.FirstOrDefault(companent => companent is PanelView);

    public void Visit(SelectorViewConfig selector) => Companent = _companents.FirstOrDefault(companent => companent is SelectorView);

    public void Visit(StatViewConfig stat) => Companent = _companents.FirstOrDefault(companent => companent is StatView);

}