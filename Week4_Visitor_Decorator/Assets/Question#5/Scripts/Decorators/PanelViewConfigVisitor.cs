using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelViewConfigVisitor : IDecoratorConfigVisitor {
    private readonly List<PanelViewConfig> _panelConfigs;
    private readonly Dictionary<string, Sprite> _selectorsData = new Dictionary<string, Sprite>();

    public PanelViewConfigVisitor(List<PanelViewConfig> panelConfigs) {
        _panelConfigs = panelConfigs;
    }

    public PanelViewConfig PanelViewConfig { get; private set; }


    public void Visit(DecoratorConfig config) => Visit((dynamic)config);

    public void Visit(RaceDecoratorConfig race) {
        PanelViewConfig = _panelConfigs.FirstOrDefault(race => race.Type == PanelTypes.Race);
        
        var races = race.GetDictionaryStringModifiers();
        GetSelectorsDataFromDecoratorConfig(races);
    }

    public void Visit(SpecializationDecoratorConfig specialization) {
        PanelViewConfig = _panelConfigs.FirstOrDefault(race => race.Type == PanelTypes.Specialization);
        
        var specializations = specialization.GetDictionaryStringModifiers();
        GetSelectorsDataFromDecoratorConfig(specializations);
    }

    public void Visit(PassiveAbilityDecoratorConfig passiveAbility) {
        PanelViewConfig = _panelConfigs.FirstOrDefault(race => race.Type == PanelTypes.PassiveAbility);

        var ability = passiveAbility.GetDictionaryStringModifiers();
        GetSelectorsDataFromDecoratorConfig(ability);
    }

    private void GetSelectorsDataFromDecoratorConfig(Dictionary<string, Modifiers> data) {
        _selectorsData.Clear();

        foreach (var item in data) {
            _selectorsData.Add($"{item.Key}", item.Value.Sprite);
        }

        PanelViewConfig.SetSelectorsData(_selectorsData);
    }
}
