using System;
using UnityEngine;

namespace Question3 {
    [RequireComponent(typeof(DestroyParticle))]
    public class Sphere : MonoBehaviour {
        [SerializeField] private Color _color;
        [SerializeField] private MeshRenderer _meshRenderer;
        [SerializeField] private DestroyParticle _destroyParticle;

        public Color Color => _color;

        public event Action<Sphere> OnSphereClicked;

        private void OnValidate() {
            _meshRenderer.sharedMaterial.color = _color;
        }
        public void MoveTo(Vector3 position) => transform.position = position;

        public void Click() {
            OnSphereClicked?.Invoke(this);
            CreateDestroySphereEffect();
        }

        public void OnMouseEnter() => transform.localScale = Vector3.one * 1.2f;

        public void OnMouseExit() => transform.localScale = Vector3.one;

        private void CreateDestroySphereEffect() {
            _destroyParticle.Show();
            Destroy(gameObject);
        }
    }
}