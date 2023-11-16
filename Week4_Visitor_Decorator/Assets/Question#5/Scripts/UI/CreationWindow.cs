using UnityEngine;

public class CreationWindow : MonoBehaviour {
    [SerializeField] private DecoratorConfigs _decoratorConfigs;
    [SerializeField] private CreationPanelsView _creationPanelsView;
    [SerializeField] private CharacterStatsView _characterStatsView;

    [SerializeField] private UICompanentsFactory _uICompanentFactory;

    private void Start() {
        _creationPanelsView.Init(_decoratorConfigs, _uICompanentFactory);
        _characterStatsView.Init(_decoratorConfigs, _uICompanentFactory, _creationPanelsView);
    }


}
