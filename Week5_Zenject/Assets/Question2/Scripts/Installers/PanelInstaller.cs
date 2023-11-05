using UnityEngine;
using Zenject;

namespace Question2 {
    public class PanelInstaller : MonoInstaller {
        [SerializeField] private DefeatPanel _defeatPanel;

        public override void InstallBindings() {
            InstallDefeatPanel();
        }

        private void InstallDefeatPanel() {
            Container.Bind<DefeatPanel>().FromInstance(_defeatPanel).AsSingle();
        }
    }
}