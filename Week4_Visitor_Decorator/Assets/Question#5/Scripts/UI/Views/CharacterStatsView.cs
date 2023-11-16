using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsView : MonoBehaviour {
    [SerializeField] private RectTransform _statsParent;
    [SerializeField] private List<StatViewConfig> _stateConfigs;

    private DecoratorConfigs _decoratorConfigs;
    private UICompanentsFactory _uICompanentFactory;
    private ModifiersFactory _modifiersFactory;
    private CreationPanelsView _creationPanelsView;

    private readonly List<StatView> _statViews = new List<StatView>();
    public void Init(DecoratorConfigs decoratorConfigs, UICompanentsFactory uICompanentFactory, CreationPanelsView creationPanelsView) {
        _decoratorConfigs = decoratorConfigs;
        _creationPanelsView = creationPanelsView;
        _creationPanelsView.ActiveSelectorChanged += UpdateStatsValue;

        _uICompanentFactory = uICompanentFactory;
        _uICompanentFactory.Init();

        _modifiersFactory = new ModifiersFactory(_decoratorConfigs);

        CreateStatViews();
    }

    private void CreateStatViews() {
        foreach (var iState in _stateConfigs) {
            StatView newState = _uICompanentFactory.Get<StatView>(iState, _statsParent);
            newState.Init(iState);

            _statViews.Add(newState);
        }
    }

    private void UpdateStatsValue() {
        List<Modifiers> ListModifiers = new List<Modifiers>();

        foreach (var iPanel in _creationPanelsView.Panels) {
            PanelTypes panelType = iPanel.Config.Type;
            string selectorName = iPanel.ActiveSelector.Config.Name;
            
            Modifiers mod = _modifiersFactory.Get(panelType, selectorName);


            ListModifiers.Add(mod);
        }

        CreateCharacter();
    }

    public void CreateCharacter() {
        //Character character = new Character(_race, _spec, _passiveAbility, _decoratorConfigs);

        //CharacterStats stats = character.Provider.GetStats();

        //Debug.Log($"Race: {_race}, Spec: {_spec}, PassiveAbility: {_passiveAbility}");
        //Debug.Log("Strength: " + stats.Strength);
        //Debug.Log("Intelligence: " + stats.Intelligence);
        //Debug.Log("Agility: " + stats.Agility);
        //Debug.Log($"--------------");
    }
}
