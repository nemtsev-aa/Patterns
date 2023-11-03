using System.Collections.Generic;
using UnityEngine;

public  abstract class VictoryCondition : Condition {
    protected IEnumerable<Sphere> Spheres;
    protected InputSystem InputSystem;

    public VictoryCondition(IEnumerable<Sphere> spheres, InputSystem inputSystem) {
        Spheres = spheres;
        InputSystem = inputSystem;

        CreateSubscribes();
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
            }
        }
    }

    protected abstract void CountNumberSpheres(Sphere sphere);
}
