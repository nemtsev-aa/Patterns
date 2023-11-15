using System.Collections.Generic;
using UnityEngine;

public class CharacterStatsView : MonoBehaviour {
    [SerializeField] private RectTransform _statsParent;
    [SerializeField] private List<StatViewConfig> _stateConfigs;
    
    private List<StatView> _statViews = new List<StatView>();
    private UICompanentsFactory _uICompanentFactory;

    public void Init(UICompanentsFactory uICompanentFactory) {
        _uICompanentFactory = uICompanentFactory;
        _uICompanentFactory.Init();

        CreateStatViews();
    }

    private void CreateStatViews() {
        foreach (var iState in _stateConfigs) {
            StatView newState = _uICompanentFactory.Get<StatView>(iState, _statsParent);
            newState.Init(iState);

            _statViews.Add(newState);
        }
    }

    private void UpdateStatsValue(Character character) {
        
    }
}
