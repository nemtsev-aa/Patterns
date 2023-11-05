using System;
using UnityEngine;

namespace Question3 {
    public class SphereVariantsView : MonoBehaviour {
        [SerializeField] private VariantView _variantViewPrefab;
        
        public event Action<Sphere> SphereTypeSelected;
        
        public void Init(SpherePrefabConfig config) {
            foreach (var iPrefab in config.Spheres) {
                VariantView newVariant = Instantiate(_variantViewPrefab, transform);
                newVariant.SetColor(iPrefab);

                newVariant.SphereTypeSelected += SetSphereType;
            }
        }

        private void SetSphereType(Sphere sphere) {
            SphereTypeSelected?.Invoke(sphere);
        }
    }
}