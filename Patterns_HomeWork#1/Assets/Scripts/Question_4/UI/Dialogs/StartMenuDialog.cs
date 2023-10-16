using System;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuDialog : Dialog {
    public SphereVariantsView SphereVariantView => _sphereVariantView;

    [SerializeField] private Button _allSphereButton;
    [SerializeField] private Button _sameColorButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private SphereVariantsView _sphereVariantView;

    public event Action<VictoryCondition> OnConditionSelected;
    
    private void Start() {
        _allSphereButton.onClick.AddListener(SelectModeAllSphere);
        _sameColorButton.onClick.AddListener(() => ShowSphereVariantsView(true));
        _exitButton.onClick.AddListener(ExitButtonClick);
        ShowSphereVariantsView(false);
        
        _sphereVariantView.SphereTypeSelected += SetSphereType;
    }

    private void SetSphereType(Sphere sphere) {
        OnConditionSelected?.Invoke(new SameColorSphereDestroyed(sphere));
        ShowSphereVariantsView(false);
    }

    private void ShowSphereVariantsView(bool status) {
        _sphereVariantView.gameObject.SetActive(status);
    }

    private void SelectModeAllSphere() {
        OnConditionSelected?.Invoke(new AllSphereDestroyed());
    }

    private void ExitButtonClick() {
        Close();
    }
}
