using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuDialog : Dialog, IDisposable {
    [SerializeField] private Button _allSphereButton;
    [SerializeField] private Button _sameColorButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private SphereVariantsView _sphereVariantView;

    public SphereVariantsView SphereVariantView => _sphereVariantView;

    public event Action AllColorVictoryConditionSelected;
    public event Action<Sphere> SameColorVictoryConditionSelected;

    public void Init(IEnumerable<Sphere> spheresPrefabs) {
        _allSphereButton.onClick.AddListener(SelectModeAllSphere);
        _sameColorButton.onClick.AddListener(() => ShowSphereVariantsView(true));
        _exitButton.onClick.AddListener(ExitButtonClick);
        
        ShowSphereVariantsView(false);
        
        _sphereVariantView.Init(spheresPrefabs);
        _sphereVariantView.SphereTypeSelected += SetSphereType;
    }

    private void SetSphereType(Sphere sphere) {
        SameColorVictoryConditionSelected?.Invoke(sphere);
        ShowSphereVariantsView(false);
    }

    private void ShowSphereVariantsView(bool status) => _sphereVariantView.gameObject.SetActive(status);

    private void SelectModeAllSphere() => AllColorVictoryConditionSelected?.Invoke();
    
    private void ExitButtonClick() => Close();

    public override void Dispose() {
        _allSphereButton.onClick.RemoveListener(SelectModeAllSphere);
        _sameColorButton.onClick.RemoveListener(() => ShowSphereVariantsView(true));
        _exitButton.onClick.RemoveListener(ExitButtonClick);
    }
}
