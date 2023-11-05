using Question3;
using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller {
    [SerializeField] private SpherePrefabConfig _spherePrefabConfig;

    public override void InstallBindings() {
        BindSpherePrefabConfig();
        BindLoader();
    }

    private void BindSpherePrefabConfig() {
        Container.Bind<SpherePrefabConfig>().FromInstance(_spherePrefabConfig).AsSingle();
    }

    private void BindLoader() {
        Container.Bind<ZenjectSceneLoaderWrapper>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoader>().AsSingle();
        Container.BindInterfacesAndSelfTo<SceneLoadMediator>().AsSingle();
    }
}
