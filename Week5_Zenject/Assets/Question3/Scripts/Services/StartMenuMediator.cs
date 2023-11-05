using UnityEngine;
using Zenject;

namespace Question3 {
    public class StartMenuMediator : MonoBehaviour {
        [SerializeField] private RectTransform _dialogsParent;

        private DialogFactory _dialogFactory;
        private StartMenuDialog _startMenu;

        private ISceneLoadMediator _sceneLoader;
        private SpherePrefabConfig _config;

        [Inject]
        private void Construct(DialogFactory dialogFactory, ISceneLoadMediator sceneLoadMediator, SpherePrefabConfig config) {
            _sceneLoader = sceneLoadMediator;
            _dialogFactory = dialogFactory;
            _config = config;

            PrepareUI();
        }

        private void PrepareUI() {
            _startMenu = _dialogFactory.GetDialog<StartMenuDialog>(_dialogsParent);
            _startMenu.ConditionSelected += SetVictoryCondition;

            _startMenu.Show(true);
        }

        private void SetVictoryCondition(LevelLoadingData data) {
            _sceneLoader.GoToGameplayLevel(data);
        }

        private void OnDestroy() {
            _startMenu.ConditionSelected += SetVictoryCondition;
        }
    }
}