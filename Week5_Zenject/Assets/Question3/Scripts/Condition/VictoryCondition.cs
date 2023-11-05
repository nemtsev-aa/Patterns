using System.Collections.Generic;
using UnityEngine;

namespace Question3 {
    public abstract class VictoryCondition : Condition {
        protected IEnumerable<Sphere> Spheres;
        protected InputSystem InputSystem;

        public VictoryCondition(IEnumerable<Sphere> spheres, InputSystem inputSystem) {
            Spheres = spheres;
            InputSystem = inputSystem;

            CreateSubscribes();
        }

        ~VictoryCondition() {
            // Код, который будет выполнен при удалении объекта из памяти
            Debug.Log($"Deleting {this}");
        }

        public Color Color { get; private set; }

        public void SetColorDestroyedSpheres(Color color) {
            Color = color;
        }

        protected void CreateSubscribes() {
            InputSystem.Clicked += ClickRegistration;

            foreach (var iSphere in Spheres) {
                iSphere.OnSphereClicked += CountNumberSpheres;
            }
        }

        private void ClickRegistration(Vector3 mousePosition) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.TryGetComponent(out Sphere sphere)) {
                    sphere.Click();
                    sphere.OnSphereClicked -= CountNumberSpheres;
                }
            }
        }

        protected abstract void CountNumberSpheres(Sphere sphere);
    }
}