using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Question3 {
    public class StartMenuDialog : Dialog {
        [SerializeField] private Button _allSphereButton;
        [SerializeField] private Button _sameColorButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private SphereVariantsView _sphereVariantView;
 
        public SphereVariantsView SphereVariantView => _sphereVariantView;

        public event Action<LevelLoadingData> ConditionSelected;
          
        [Inject]
        private void Construct(SpherePrefabConfig config) {
            AddListeners();

            _sphereVariantView.Init(config);
            ShowSphereVariantsView(false);
            _sphereVariantView.SphereTypeSelected += SetSphereType;
        }

        public override void Dispose() => RemoveListeners();

        private void SetSphereType(Sphere sphere) {
            LevelLoadingData data = new LevelLoadingData(VictoryConditionTypes.SameColor, sphere.Color);
            ConditionSelected?.Invoke(data);

            ShowSphereVariantsView(false);
        }

        private void SelectModeAllSphere() {
            LevelLoadingData data = new LevelLoadingData(VictoryConditionTypes.AllColor, Color.clear);
            ConditionSelected?.Invoke(data);
        }

        private void ShowSphereVariantsView(bool status) => _sphereVariantView.gameObject.SetActive(status);

        private void AddListeners() {
            _allSphereButton.onClick.AddListener(SelectModeAllSphere);
            _sameColorButton.onClick.AddListener(() => ShowSphereVariantsView(true));
            _exitButton.onClick.AddListener(ExitButtonClick);
        }

        private void RemoveListeners() {
            _allSphereButton.onClick.RemoveListener(SelectModeAllSphere);
            _sameColorButton.onClick.RemoveListener(() => ShowSphereVariantsView(true));
            _exitButton.onClick.RemoveListener(ExitButtonClick);
        }

        private void ExitButtonClick() => Close();
    }
}