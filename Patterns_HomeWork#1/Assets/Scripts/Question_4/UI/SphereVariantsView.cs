using System;
using System.Collections.Generic;
using UnityEngine;

public class SphereVariantsView : MonoBehaviour {
    [SerializeField] private VariantView _variantViewPrefab;
    public event Action<Sphere> SphereTypeSelected;

    public void Init(IEnumerable<Sphere> spherePrefabs) {
        foreach (var iPrefab in spherePrefabs) {
            VariantView newVariant = Instantiate(_variantViewPrefab, transform);
            newVariant.SetColor(iPrefab);
            newVariant.SphereTypeSelected += SetSphereType;
        }
    }

    private void SetSphereType(Sphere sphere) {
        SphereTypeSelected?.Invoke(sphere);
    }
}
