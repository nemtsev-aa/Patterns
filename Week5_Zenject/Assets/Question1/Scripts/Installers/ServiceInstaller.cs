using Zenject;

public class ServiceInstaller : MonoInstaller {
    public override void InstallBindings() {
        Container.BindInterfacesAndSelfTo<PauseHandler>().AsSingle();
    }
}
