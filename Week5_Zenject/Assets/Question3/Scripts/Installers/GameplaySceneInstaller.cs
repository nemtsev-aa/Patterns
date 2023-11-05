using Question3;
using UnityEngine;
using Zenject;

public class GameplaySceneInstaller : MonoInstaller {
    [SerializeField] private RectTransform _dialogsParent;
    [SerializeField] private SpheresSpawner _spheresSpawner;
    [SerializeField] private PlacerConfig _placerConfig;

    private LevelLoadingData _levelLoadingData;
    
    [Inject]
    private void Construct(LevelLoadingData levelLoadingData) {
        _levelLoadingData = levelLoadingData;
    }
    
    public override void InstallBindings() {
        BindLevelLoadingData();
        BindInput();

        BindPlacerConfig();
        BindSpheresPlacer();
        BindLevel();

        BindDialogsParent();
        BindDialogSwitcher();
        BindDialogFactory();

        BildSpheresSpawner();
        BindSphereFactory();

        BindVictoryConditionFactory();
        BildVictoryConditionSwitcher();
    }

    private void BindLevelLoadingData() {
        Container.Bind<LevelLoadingData>().FromInstance(_levelLoadingData);
    }

    private void BindInput() {
        Container.BindInterfacesAndSelfTo<InputSystem>().AsSingle();
    }

    private void BindDialogFactory() {
        Container.Bind<DialogFactory>().FromNew().AsSingle();
    }

    private void BindDialogsParent() {
        Container.Bind<RectTransform>().FromInstance(_dialogsParent);
    }

    private void BindSphereFactory() {
        Container.Bind<SphereFactory>().FromNew().AsSingle();
    }

    private void BindVictoryConditionFactory() {
        Container.Bind<VictoryConditionFactory>().FromNew().AsSingle();
    }

    private void BildSpheresSpawner() {
        Container.Bind<SpheresSpawner>().FromInstance(_spheresSpawner);
    }

    private void BildVictoryConditionSwitcher() {
        Container.Bind<VictoryConditionSwitcher>().FromNew().AsSingle();
    }

    private void BindDialogSwitcher() {
        Container.Bind<DialogSwitcher>().FromNew().AsSingle();
    }

    private void BindPlacerConfig() {
        Container.Bind<PlacerConfig>().FromInstance(_placerConfig);
    }

    private void BindSpheresPlacer() {
        Container.Bind<SpheresPlacer>().FromNew().AsSingle();
    }

    private void BindLevel() {
        Container.Bind<Level>().FromNew().AsSingle();
    }
}
