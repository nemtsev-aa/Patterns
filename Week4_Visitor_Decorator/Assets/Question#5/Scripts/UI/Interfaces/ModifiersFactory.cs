using System;
using System.Collections.Generic;
using System.Linq;

public class ModifiersFactory {
    private readonly DecoratorConfigs _decoratorConfigs;

    public ModifiersFactory(DecoratorConfigs decoratorConfigs) {
        _decoratorConfigs = decoratorConfigs;
    }

    public Modifiers Get(PanelTypes type, string selectorName) {
        Modifiers value;

        switch (type) {
            case PanelTypes.Race:
                var raceConfig = _decoratorConfigs.GetConfigByType<RaceDecoratorConfig>();
                GetModifier(raceConfig, selectorName, out value);
                raceConfig.GetKeyByValue(value);

                return value;

            case PanelTypes.Specialization:
                var specConfig = _decoratorConfigs.GetConfigByType<SpecializationDecoratorConfig>();
                GetModifier(specConfig, selectorName, out value);
                return value;

            case PanelTypes.PassiveAbility:
                var abilityConfig = _decoratorConfigs.GetConfigByType<PassiveAbilityDecoratorConfig>();
                GetModifier(abilityConfig, selectorName, out value);
                return value;

            default:
                throw new ArgumentNullException($"Invalide PanelType: {type}");
        }
    }

    private void GetModifier(DecoratorConfig config, string selectorName, out Modifiers value) {
        Dictionary<string, Modifiers> modifiers = config.GetDictionaryStringModifiers();
        
        if (modifiers.TryGetValue(selectorName, out value)) { }
    }
}
