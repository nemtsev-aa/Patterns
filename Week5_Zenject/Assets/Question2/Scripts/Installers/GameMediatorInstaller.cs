using Zenject;

namespace Question2 {
    public class GameMediatorInstaller : MonoInstaller {
        public override void InstallBindings() {
            InstallLevel();
            InstallMediator();
        }

        private void InstallLevel() {
            Container.Bind<Level>().AsSingle();
        }

        private void InstallMediator() {
            Container.BindInterfacesAndSelfTo<GameplayMediator>().AsSingle().NonLazy();
        }
    }
}