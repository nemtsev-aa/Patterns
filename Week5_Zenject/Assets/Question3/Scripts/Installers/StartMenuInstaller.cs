using Question3;
using Zenject;

public class StartMenuInstaller : MonoInstaller {
    
    public override void InstallBindings() {
        BindDialogFactory();
    }

    private void BindDialogFactory() {
        Container.Bind<DialogFactory>().FromNew().AsSingle();
    }
}
