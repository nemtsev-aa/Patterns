using System;
using UnityEngine;
using UnityEngine.UI;

public class VariantView : MonoBehaviour {
    [SerializeField] private Image _sphereColor;
    [SerializeField] private Button _selectSphereTypeButton;

    public event Action<Sphere> SphereTypeSelected;
    private Sphere _sphere;

    public void SetColor(Sphere sphere) {
        _sphere = sphere;
        _sphereColor.color = _sphere.MeshRenderer.sharedMaterial.color;
    }

    private void Start() {
        _selectSphereTypeButton.onClick.AddListener(SelectSphereTypeButtonClick);
    }

    private void SelectSphereTypeButtonClick() {
        SphereTypeSelected?.Invoke(_sphere);
    }
}